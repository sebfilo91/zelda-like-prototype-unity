using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public void Close() {
		//Animation fermeture
		transform.collider2D.enabled = true;
	}

	public void Open() {
		//Animation ouverture
		transform.collider2D.enabled = false;
	}
	
	public void OnTriggerEnter2D(Collider2D other) {
		
		Debug.Log("Door Collision with : " + other.gameObject.name);
		if(other.gameObject.tag == "Player") {
			if(transform.gameObject.name == "TopDoor") {
				GameLogic.roomSwitch = true;
				Debug.Log("GameLogic.roomSwitch = true;");
			}
		}
	}
	public void OnTriggerExit2D(Collider2D other) {

		if(other.gameObject.tag == "Player") {
			if(transform.gameObject.name == "TopDoor") {
				GameLogic.roomSwitch = false;
			}
			if(transform.gameObject.name == "BotDoor") {
				this.Close();
			}
		}
	}

}
