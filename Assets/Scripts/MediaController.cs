using UnityEngine;
using System.Collections;

public class MediaController : MonoBehaviour
{
	public ConditionActionK myKind;
	public string MediaId;

	public GameObject[] prefabs;
	private Object currentIcon;
 
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
			if (MyKind != value) {
				myKind = value;
				this.InstantiateCurrentKind ();
			}
		}
	}

	private void InstantiateCurrentKind(){
		Destroy (currentIcon);
		currentIcon = Instantiate(prefabs [(int)this.MyKind], transform, false);
	}
}

