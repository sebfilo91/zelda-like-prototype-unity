using UnityEngine;
using System.Collections;

public class AndroidDebug : MonoBehaviour {
	public string debugText  = "";
	// Update is called once per frame
	void OnGUI () {

		debugText = "";

		Debug.Log(Input.gyro.userAcceleration);
		Debug.Log(Input.gyro.attitude);
		Debug.Log(Input.gyro.gravity);
		Debug.Log(Input.gyro.rotationRate);
		Debug.Log(Input.gyro.rotationRateUnbiased);
		Debug.Log(Input.gyro.updateInterval);
		Debug.Log(Input.gyro.userAcceleration);


		//debugText += "userAcceleration : " + Input.gyro.userAcceleration;
		//debugText += "gravity : " + Input.gyro.gravity;
		//debugText += "rotationRate : " + Input.gyro.rotationRate;
		//debugText += "rotationRateUnbiased : " + Input.gyro.rotationRateUnbiased;
		//debugText += "updateInterval : " + Input.gyro.updateInterval;

		GUI.Label(new Rect(0,0,100,Screen.height),debugText);
	}
}
