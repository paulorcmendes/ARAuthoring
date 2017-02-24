using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Focus : MonoBehaviour {
	private bool flash;
	// Use this for initialization
	void Start () 
	{
		//VuforiaBehaviour.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
		//VuforiaBehaviour.Instance.RegisterOnPauseCallback(OnPaused);
		OnVuforiaStarted();
		flash = false;
	}

	private void OnVuforiaStarted()
	{
		CameraDevice.Instance.SetFocusMode(
		CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);		
	}

	private void OnPaused(bool paused)
	{
		if (!paused) // resumed
		{
			// Set again autofocus mode when app is resumed
			CameraDevice.Instance.SetFocusMode(
			CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		}
	}
	void Update(){
		if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began) {
			flash = !flash;
			CameraDevice.Instance.SetFlashTorchMode (flash);
		}
	}
}
