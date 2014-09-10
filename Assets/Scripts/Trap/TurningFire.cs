using UnityEngine;
using System.Collections;

public class TurningFire : MonoBehaviour {
	public float rotationSpeed = 1;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,0,rotationSpeed));
	}

}
