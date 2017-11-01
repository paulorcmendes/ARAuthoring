using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MediaControllerScript : MonoBehaviour {

    //public GameObject[] medias;

    public delegate void MyHandler();

    public event MyHandler Port;
	// Use this for initialization
	void Start () {        
        /*ConnectorBase.OnEndStop(medias[1], medias[3]);
        ConnectorBase.OnEndStart(medias[3], medias[0]);
        OnEntry(medias[1]);
        ConnectorBase.OnBeginStart(medias[1], medias[3]);*/
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButton(0)) Play();
	}

    private void Play() {
        if(Port != null)  this.Port();
    }

    public void OnEntry(GameObject media)
    {
        Debug.Log("Port " + media.GetComponent<MediaKind>().MediaId);
        this.Port += media.GetComponent<MediaSettings>().Play;
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
