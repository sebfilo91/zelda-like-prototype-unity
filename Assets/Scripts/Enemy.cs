using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float speed = 300;
	public float hp = 10;
	public float collisionDamage = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Si player dans la zone 
			//Attack le player
		//Si pas player dans la zone
			//Bouge à droite à gauche etc..
	}
	
	public void Die() {
		Destroy(transform.gameObject);	
		GameLogic.enemiesLeft--;
	}
	

}
