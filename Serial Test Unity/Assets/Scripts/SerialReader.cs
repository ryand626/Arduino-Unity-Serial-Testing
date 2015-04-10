using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;

public class SerialReader : MonoBehaviour {
	//Setup parameters to connect to Arduino
	public static SerialPort sp = new SerialPort("COM9", 9600, Parity.None, 8, StopBits.One);
	public static string inputString;
	
	// Game Objects
	public List<GameObject> SmartObjects = new List<GameObject>();
	private List<GameObject> toDestroy = new List<GameObject>();
	// Object Timeout
	public float timeBuffer;
	
	// Initialization
	void Start () {
		timeBuffer = 1f; // Objects are removed from the gamespace after 1 second of disconnection
		OpenConnection();
	}
	
	void Update(){
		ReadSerial ();
		UpdateSmartObjects(inputString);
		CheckConnectivity ();
	}
	
	// Open Connection to the Arduino
	public void OpenConnection() {
		if (sp != null) {
			if (sp.IsOpen) {
				sp.Close();
				print("Closing port, because it was already open!");
			}else {
				sp.Open();                // opens the connection
				sp.ReadTimeout = 50;      // sets the timeout value before reporting error
				print("Port Opened!");
			}
		}else {
			if (sp.IsOpen){
				print("Port is already open");
			}else {
				print("Port == null");
			}
		}
	}
	
	// Close the Serial Port when the program closes
	void OnApplicationQuit() {
		sp.Close();
	}
	
	// Read in a line from the serial port
	void ReadSerial(){
		inputString = "";
		try{
			inputString = sp.ReadLine();
			//print (inputString);
		}
		catch(Exception e) {}
	}
	
	void UpdateSmartObjects(string message){
		print (message.Length);
		if (message.Length <= 11 || message.Length > 15) {
			return; // return if the message is not the correct length
		}
		
		// Parse the data
		int id = (int)message[0]-48;
		int button1 = (int)message[2]-48;
		int button2 = (int)message[4]-48;
		int led1 = (int)message[6]-48;
		int led2 = (int)message[8]-48;
		string pot_str = "";
		for (int i=10; i<message.Length; i++) {
			pot_str += message[i];
		}
		float pot = float.Parse(pot_str);
		
		// Either make, or get a reference to the object
		SmartObject ObjectInfo;
		if (Exists (id)) {
			GameObject oldObject = SmartObjects.Find(GameObject => GameObject.GetComponent<SmartObject>().id == id);
			ObjectInfo = oldObject.GetComponent<SmartObject> ();
		} else {
			print ("Making a new object " + id);
			GameObject newObject = (GameObject)Instantiate(Resources.Load("PreFabs/SmartObject"));
			newObject.transform.Translate(Vector3.right*(id-2.5f));
			newObject.name = id.ToString();
			ObjectInfo = newObject.GetComponent<SmartObject>();
			SmartObjects.Add(newObject);
		}
		// Set the information according to the information in the message
		ObjectInfo.id = id;
		ObjectInfo.button1 = button1.Equals (1);
		ObjectInfo.button2 = button2.Equals (1);
		ObjectInfo.LED1 = led1.Equals (1);
		ObjectInfo.LED2 = led2.Equals (1);
		ObjectInfo.pot = pot;
		ObjectInfo.timeout = Time.timeSinceLevelLoad;
	}
	
	// Check if the object exists
	public bool Exists(int id){
		if (SmartObjects.Find(GameObject => GameObject.GetComponent<SmartObject>().id == id)){
			return true;
		}
		return false;
	}
	
	void CheckConnectivity(){
		// If an object times out...
		foreach (GameObject obj in SmartObjects){
			if(obj.GetComponent<SmartObject>().timeout < Time.timeSinceLevelLoad - timeBuffer){
				// ...add it to the destruction list...
				toDestroy.Add(obj);
			}
		}
		// ...then remove and destroy it
		foreach (GameObject obj in toDestroy) {
			SmartObjects.Remove(obj);
			Destroy(obj);
		}
	}
}
