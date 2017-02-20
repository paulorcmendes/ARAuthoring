using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conditionScript : MonoBehaviour {
	public string myName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (new Vector3(0.01f, 0, 0));
	}
	void OnCollisionEnter(Collision collision){
		Debug.Log ("bateu");
		transform.parent = collision.gameObject.transform.parent;
		//transform.position = collision.gameObject.transform.position;
		//transform.rotation = collision.gameObject.transform.rotation;
		//transform.Translate (new Vector3 (1, 0, 0));
	}

}
