using UnityEngine;
using System.Collections;

public class ObjectBehavior : MonoBehaviour {
	SmartObject ObjectInfo;

	GameObject Button1;
	GameObject Button2;
	GameObject LED1;
	GameObject LED2;
	GameObject pot;

	// Use this for initialization
	void Start () {
		ObjectInfo = GetComponent<SmartObject> ();
		Button1 = transform.FindChild ("Button1").gameObject;
		Button2 = transform.FindChild ("Button2").gameObject;
		LED1 = transform.FindChild ("LED1").gameObject;
		LED2 = transform.FindChild ("LED2").gameObject;
		pot = transform.FindChild ("pot").gameObject;

	}
	
	// Update is called once per frame
	void Update () {
		//ObjectInfo = GetComponent<SmartObject> ();
		UpdateButtons ();
		UpdateLEDs ();
		UpdatePot ();
	}

	void UpdateButtons(){
		if (ObjectInfo.button1) {
			Button1.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
		} else {
			Button1.gameObject.GetComponent<Renderer>().material.color = Color.white;
		}

		if (ObjectInfo.button2) {
			Button2.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
		} else {
			Button2.gameObject.GetComponent<Renderer>().material.color = Color.white;
		}
	}

	void UpdateLEDs(){
		if (ObjectInfo.LED1) {
			LED1.gameObject.GetComponent<Renderer>().material.color = Color.red;
		} else {
			LED1.gameObject.GetComponent<Renderer>().material.color = Color.white;
		}
		if (ObjectInfo.LED2) {
			LED2.gameObject.GetComponent<Renderer>().material.color = Color.blue;
		} else {
			LED2.gameObject.GetComponent<Renderer>().material.color = Color.white;
		}
	}

	void UpdatePot(){
		pot.transform.eulerAngles = new Vector3(0,(ObjectInfo.pot/1024f)*360,0);
	}
}
