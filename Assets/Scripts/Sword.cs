using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
	public int damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		GameObject objCol = collider.gameObject;
		if(objCol.tag == "Enemy" && !collider.isTrigger) {
			Enemy enemy = objCol.GetComponent<Enemy>();
			enemy.hp = enemy.hp - damage;
			Debug.Log(enemy.name + " hps = " + enemy.hp);
			if(enemy.hp<= 0) {
				enemy.Die();
			}
		}
	}
}
