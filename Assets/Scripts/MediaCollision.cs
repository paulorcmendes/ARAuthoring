using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MediaCollision : MonoBehaviour {
	
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Condition")) {
			ConditionActionK colK = collision.gameObject.GetComponent<ConditionAction> ().MyKind;
			gameObject.GetComponent<Instantiator> ().MyKind = colK;
			gameObject.tag = "ConditionMedia";
		}
		else if (collision.gameObject.CompareTag ("Action")) {
			ConditionActionK colK = collision.gameObject.GetComponent<ConditionAction> ().MyKind;
			gameObject.GetComponent<Instantiator> ().MyKind = colK;
			gameObject.tag = "ActionMedia";
		}

		else if (gameObject.CompareTag ("ConditionMedia")) {
			Instantiator Inst = gameObject.GetComponent<Instantiator> ();
			Instantiator colInst = collision.gameObject.GetComponent<Instantiator> ();
			if (collision.gameObject.CompareTag ("ActionMedia")) {
				Debug.Log (
					Enum.GetName (typeof(ConditionActionK), Inst.MyKind)+" "+Inst.MediaId+" "+
					Enum.GetName (typeof(ConditionActionK), colInst.MyKind)+" "+colInst.MediaId+" "
				);				
			}
		}
	}

}
