using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MediaCollision : MonoBehaviour {
	private Text text;

	void Start () 
	{
		text = GameObject.FindGameObjectWithTag ("OutText").GetComponent<Text>();
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Condition")) {
			ConditionActionK colK = collision.gameObject.GetComponent<ConditionAction> ().MyKind;
			gameObject.GetComponent<MediaController> ().MyKind = colK;
			gameObject.tag = "ConditionMedia";
		}
		else if (collision.gameObject.CompareTag ("Action")) {
			ConditionActionK colK = collision.gameObject.GetComponent<ConditionAction> ().MyKind;
			gameObject.GetComponent<MediaController> ().MyKind = colK;
			gameObject.tag = "ActionMedia";
		}

		else if (gameObject.CompareTag ("ConditionMedia")) {
			MediaController Inst = gameObject.GetComponent<MediaController> ();
			MediaController colInst = collision.gameObject.GetComponent<MediaController> ();
			if (collision.gameObject.CompareTag ("ActionMedia")) {
				Debug.Log (
					Enum.GetName (typeof(ConditionActionK), Inst.MyKind)+" "+Inst.MediaId+" "+
					Enum.GetName (typeof(ConditionActionK), colInst.MyKind)+" "+colInst.MediaId+" "
				);
				text.text = Enum.GetName (typeof(ConditionActionK), Inst.MyKind) + " " + Inst.MediaId + " " +
							Enum.GetName (typeof(ConditionActionK), colInst.MyKind) + " " + colInst.MediaId + " ";
			}
		}
	}

}
