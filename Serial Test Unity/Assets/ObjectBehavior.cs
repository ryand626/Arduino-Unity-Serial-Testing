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
			Button1.transform.Rotate (Vector3.up);
		} else {
			Button1.transform.Rotate (Vector3.up*-1f);
		}

		if (ObjectInfo.button2) {
			Button2.transform.Rotate (Vector3.up);
		} else {
			Button2.transform.Rotate (Vector3.up*-1f);
		}
	}

	void UpdateLEDs(){
		if (ObjectInfo.LED1) {
			LED1.transform.Rotate (Vector3.up);
		} else {
			LED1.transform.Rotate (Vector3.up*-1f);
		}
		if (ObjectInfo.LED2) {
			LED2.transform.Rotate (Vector3.up);
		} else {
			LED2.transform.Rotate (Vector3.up*-1f);
		}
	}

	void UpdatePot(){
		pot.transform.rotation = Quaternion.Euler(new Vector3(0,0,ObjectInfo.pot));
	}
}
