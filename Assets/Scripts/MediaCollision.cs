using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaCollision : MonoBehaviour {
	
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Condition")) {
			ConditionActionK colK = collision.gameObject.GetComponent<ConditionAction> ().MyKind;
			gameObject.GetComponent<Instantiator> ().MyKind = colK;

			gameObject.tag = "ConditionMedia";
		}
		if (collision.gameObject.CompareTag ("Action")) {
			ConditionActionK colK = collision.gameObject.GetComponent<ConditionAction> ().MyKind;
			gameObject.GetComponent<Instantiator> ().MyKind = colK;
			gameObject.tag = "ActionMedia";
		}
	}

}
