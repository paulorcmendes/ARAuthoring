using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum CurrentMode {EDITING, PLAYING}

public class MediaControllerScript : MonoBehaviour {

    public delegate void MyHandler();
    public CurrentMode myMode;
    private GameObject ARCamera;
    public event MyHandler Port;
	// Use this for initialization
	void Start () {
        ARCamera = GameObject.FindGameObjectWithTag("ARCamera");
        myMode = CurrentMode.EDITING;
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
    }
    public void RemoveEntry(GameObject media)
    {
        Debug.Log("Port Removed " + media.GetComponent<MediaKind>().MediaId);
        this.Port -= media.GetComponent<MediaSettings>().Play;
    }
    public void CreateLink(GameObject mediaCondition, GameObject mediaAction) {
        Debug.Log(
            Enum.GetName(typeof(ConditionActionK), mediaCondition.GetComponent<MediaKind>().MyKind) +" "+ mediaCondition.GetComponent<MediaKind>().MediaId + " " +
            Enum.GetName(typeof(ConditionActionK), mediaAction.GetComponent<MediaKind>().MyKind)+" "+mediaAction.GetComponent<MediaKind>().MediaId + " ");
        switch (mediaCondition.GetComponent<MediaKind>().MyKind) {
            case ConditionActionK.onBegin:
                switch (mediaAction.GetComponent<MediaKind>().MyKind) {
                    case ConditionActionK.start:
                        ConnectorBase.OnBeginStart(mediaCondition, mediaAction);
                        break;
                    case ConditionActionK.stop:
                        ConnectorBase.OnBeginStop(mediaCondition, mediaAction);
                        break;
                }
                break;
            case ConditionActionK.onEnd:
                switch (mediaAction.GetComponent<MediaKind>().MyKind)
                {
                    case ConditionActionK.start:
                        ConnectorBase.OnEndStart(mediaCondition, mediaAction);
                        break;
                    case ConditionActionK.stop:
                        ConnectorBase.OnEndStop(mediaCondition, mediaAction);
                        break;
                }
                break;
        }
     }
}
