using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorBase : MonoBehaviour {

    public static void OnEndStart(GameObject mediaCondition, GameObject mediaAction)
    {
        mediaCondition.GetComponent<MediaSettings>().OnEnd += mediaAction.GetComponent<MediaSettings>().Play;
    }
    public static void OnEndStop(GameObject mediaCondition, GameObject mediaAction)
    {
        mediaCondition.GetComponent<MediaSettings>().OnEnd += mediaAction.GetComponent<MediaSettings>().Stop;
    }
    public static void OnBeginStart(GameObject mediaCondition, GameObject mediaAction)
    {
        mediaCondition.GetComponent<MediaSettings>().OnBegin += mediaAction.GetComponent<MediaSettings>().Play;
    }
    public static void OnBeginStop(GameObject mediaCondition, GameObject mediaAction)
    {
        mediaCondition.GetComponent<MediaSettings>().OnBegin += mediaAction.GetComponent<MediaSettings>().Stop;
    }
}
