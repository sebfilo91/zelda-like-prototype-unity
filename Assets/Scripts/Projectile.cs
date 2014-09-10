using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float damage = 10f;
	public float speed = 30f;

	private Vector3 playerPosition;

	private Vector3 direction;
	// Use this for initialization
	void Start () {
		transform.position = new Vector2(transform.position.x + 0.5f,transform.position.y + 0.5f);
		playerPosition = GameObject.FindWithTag("Player").transform.position;
		direction = playerPosition - transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!Physics2D.OverlapCircle(transform.position,0.1f).OverlapPoint(playerPosition)) {
			direction = direction.normalized;
			transform.rigidbody2D.AddForce(direction * speed);
		} else {
			Destroy(transform.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.tag);
		if(other.tag == "Player" || other.tag == "Block" || other.tag == "Wall") {
			if(other.tag == "Player") {
				Player player = other.GetComponent<Player>();
				player.hp = player.hp - damage;
			}
			Destroy(transform.gameObject);
		}
	}
}
