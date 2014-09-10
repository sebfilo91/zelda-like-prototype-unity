using UnityEngine;
using System.Collections;



public class Player : MonoBehaviour {
	public float hp = 100;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(hp<=0) {
			Die();

		}
	}

	void OnCollisionEnter2D(Collision2D  col)  {
		if(col.gameObject.tag == "Enemy") {
			Enemy enemy = col.gameObject.GetComponent<Enemy>();
			hp = hp - enemy.collisionDamage;
		} else if(col.gameObject.tag == "Tower") {
			Tower tower = col.gameObject.GetComponent<Tower>();
			tower.Trigger();
		}
	}

	public void Die() {
		//Play animation
		Destroy(transform.gameObject);

	}
}
