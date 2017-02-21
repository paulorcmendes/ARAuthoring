using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour
{
	public ConditionActionK myKind;
	// Use this for initialization
	void Start ()
	{
		MyKind = ConditionActionK.none;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public ConditionActionK MyKind{
		get{ 
			return myKind;
		}
		set{ 
			myKind = value;
		}
	}
}

