using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;


public class serialTest : MonoBehaviour {

	//Setup parameters to connect to Arduino
	public static SerialPort sp = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
	public static string strIn;
	
	int packetsSent = 0;

	// Visulalization parameters
	Vector3 initialPosition;


	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		OpenConnection();
	}
	
	void Update(){
		// Read incoming data
		try{
			// READ
			strIn = sp.ReadLine();
			print(strIn);
			transform.position = parseInput(strIn)*(1f/255f) + initialPosition;
			// WRITE
//			sp.WriteLine("UNITY: " + packetsSent);
//			packetsSent++;
		}
		catch(Exception e) {

		}
	}
	
	// Open Connection to the Arduino
	public void OpenConnection() {
		if (sp != null) 
		{
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

	Vector3 parseInput(string input){
		int numComplete = 0;
		string x = "";
		string y = "";
		string z = "";
		for (int i = 0; i < input.Length; i++) {
			if(input[i] != ','){
				if(numComplete == 0){
					x += input[i];
				}
				if(numComplete == 1){
					y += input[i];
				}
				if(numComplete == 2){
					z += input[i];
				}
			}else{
				numComplete ++;
			}
		}
		return new Vector3 (float.Parse (x), float.Parse (y), float.Parse (z));
	}
}