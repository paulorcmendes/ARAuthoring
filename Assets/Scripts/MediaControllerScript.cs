using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum CurrentMode {EDITING, PLAYING}

public class MediaControllerScript : MonoBehaviour {

    public delegate void MyHandler();
    public CurrentMode myMode;
    public GameObject ARCamera;
    public event MyHandler Port;
    private NCLParser nclParser;
    private LinksControllerScript linksController;
    // Use this for initialization
    void Start () {
        //ARCamera = GameObject.FindGameObjectWithTag("ARCamera");
        myMode = CurrentMode.EDITING;
        nclParser = GameObject.FindGameObjectWithTag("GameController").GetComponent<NCLParser>();
        linksController = GameObject.FindGameObjectWithTag("LinksController").GetComponent<LinksControllerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) SwitchMyMode();
	}

    public void SwitchMyMode()
    {
        if (myMode == CurrentMode.EDITING)
        {
            ARCamera.SetActive(false);
            myMode = CurrentMode.PLAYING;
            Play();
            nclParser.Save();
        }
        else
        {
            ARCamera.SetActive(true);
            myMode = CurrentMode.EDITING;
        }
    }

    private void Play() {
        if(Port != null)  this.Port();
    }

    public void OnEntry(GameObject media)
    {
        Debug.Log("Port " + media.GetComponent<MediaKind>().MediaId);
        this.Port += media.GetComponent<MediaSettings>().Play;
        nclParser.AddPort(media.GetComponent<MediaKind>().MediaId);
    }
    public void RemoveEntry(GameObject media)
    {
        Debug.Log("Port Removed " + media.GetComponent<MediaKind>().MediaId);
        this.Port -= media.GetComponent<MediaSettings>().Play;
    }
    public void CreateLink(GameObject mediaCondition, GameObject mediaAction) {
        string condition = Enum.GetName(typeof(ConditionActionK), mediaCondition.GetComponent<MediaKind>().MyKind);
        string media1 = mediaCondition.GetComponent<MediaKind>().MediaId;
        string action = Enum.GetName(typeof(ConditionActionK), mediaAction.GetComponent<MediaKind>().MyKind);
        string media2 = mediaAction.GetComponent<MediaKind>().MediaId;
        string description = condition + " " + media1 + " " + action + " " + media2;
        Debug.Log(description);
        nclParser.AddLink(condition, media1, action, media2);

        switch (mediaCondition.GetComponent<MediaKind>().MyKind) {
            case ConditionActionK.onBegin:
                switch (mediaAction.GetComponent<MediaKind>().MyKind) {
                    case ConditionActionK.Start:

                        ConnectorBase.OnBeginStart(mediaCondition, mediaAction);
                        linksController.AddLink(new Link(LinkKind.onBeginStart, mediaCondition, mediaAction, description));
                        break;
                    case ConditionActionK.Stop:
                        ConnectorBase.OnBeginStop(mediaCondition, mediaAction);
                        linksController.AddLink(new Link(LinkKind.onBeginStop, mediaCondition, mediaAction, description));
                        break;
                }
                break;
            case ConditionActionK.onEnd:
                switch (mediaAction.GetComponent<MediaKind>().MyKind)
                {
                    case ConditionActionK.Start:
                        ConnectorBase.OnEndStart(mediaCondition, mediaAction);
                        linksController.AddLink(new Link(LinkKind.onEndStart, mediaCondition, mediaAction, description));
                        break;
                    case ConditionActionK.Stop:
                        linksController.AddLink(new Link(LinkKind.onEndStop, mediaCondition, mediaAction, description));
                        ConnectorBase.OnEndStop(mediaCondition, mediaAction);
                        break;
                }
                break;
        }
     }
}
