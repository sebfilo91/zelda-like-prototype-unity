using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {
	private float damage = 10;
	private bool triggerActive = true;
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("TriggerEnter TurningFire");
		if(other.tag == "Player") {
			if(triggerActive) {
				Player player = other.GetComponent<Player>();
				player.hp = player.hp - damage;
			}
			triggerActive = false;
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		triggerActive = true;
	}
}
