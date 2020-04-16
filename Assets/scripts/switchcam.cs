using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchcam : MonoBehaviour {
	public Camera MainCamera;
	public Camera DeviceCamera;
	public Image device;
	public Text Value;
	bool state = false;

	void Start(){
		MainCamera.enabled = true;
		DeviceCamera.enabled = false;
		device.enabled = false;
		Value.enabled = false;
	}

	public void ShowOverheadView() {
			MainCamera.enabled = false;
			DeviceCamera.enabled = true;
			device.enabled = true;
			Value.enabled = true;
			state = true;
	}

	public void ShowFirstPersonView() {
		MainCamera.enabled = true;
		DeviceCamera.enabled = false;
		device.enabled = false;
		Value.enabled = false;
		state = false;
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("m"))
		{
			switching ();
		}
	}

	void switching(){
		if (state == false) {
			ShowOverheadView ();
		}else{
			ShowFirstPersonView ();	
	}
}
}