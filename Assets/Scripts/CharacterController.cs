using UnityEngine;
using System.Collections;
enum Facing {
	up = 0,
	down = 1,
	left = 2,
	right = 3,
}

public class CharacterController : MonoBehaviour {
	public float speed;

	private Vector2 direction;
	private Vector2 heading;
	private Facing facing = Facing.down;

	private Animator animator;
	private float oldSpeed = 0;

	public GameObject SwordDown;
	public GameObject SwordUp;
	public GameObject SwordLeft;
	public GameObject SwordRight;

	private Vector3 mousePos;

	private bool attacking = false;
	// Use this for initialization
	void Start () {
		animator = transform.GetComponent<Animator>();
	}
	void FixedUpdate() {
		if(!attacking) {
			SimulateControls();
		}
	}
	// Update is called once per frame
	void Update () {
		//Accelrometre : de base 0 0 -1.1


		if(!(Input.acceleration.x > -0.15 && Input.acceleration.x < 0.15) &&
		   !(Input.acceleration.y > -0.15 && Input.acceleration.y < 0.15)) {
			direction = new Vector2(Input.acceleration.x,Input.acceleration.y);
			transform.rigidbody2D.AddForce(direction * speed);
		}
		if(!(Input.acceleration.x > -0.15 && Input.acceleration.x < 0.15)) {
			direction = new Vector2(Input.acceleration.x,0);
			transform.rigidbody2D.AddForce(direction * speed);
		}
		if(!(Input.acceleration.y > -0.15 && Input.acceleration.y < 0.15)) {
			direction = new Vector2(0,Input.acceleration.y);
			transform.rigidbody2D.AddForce(direction * speed);
		}

		direction = transform.InverseTransformDirection(rigidbody2D.velocity);

		if(direction.x < 0 && direction.y <0.2 && direction.y > -0.2) {
			facing = Facing.left;
			animator.SetInteger("Facing",(int)facing);
		}
		if(direction.x > 0 && direction.y <0.2 && direction.y > -0.2) {
			facing = Facing.right;
			animator.SetInteger("Facing",(int)facing);
		}
		if(direction.x <0.2 && direction.x > -0.2 && direction.y > 0) {
			facing = Facing.up;
			animator.SetInteger("Facing",(int)facing);
		}
		if(direction.x <0.2 && direction.x > -0.2 && direction.y < 0) {
			facing = Facing.down;
			animator.SetInteger("Facing",(int)facing);
		}
	
		animator.SetFloat("Speed",transform.rigidbody2D.velocity.magnitude);

		
		if(Input.GetButton("Fire1")) {
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if(mousePos.x < (Screen.width/2)) {
				StartCoroutine(Attack());	
			} else {
				UseShield();
			}
		}
	}

	public IEnumerator Attack() {
		//Activation de l'épée - Animation/Coroutine - Désactivation
		transform.rigidbody2D.velocity = new Vector3(0,0,0);
		attacking = true;
		animator.SetBool("Attacking",attacking);
		if(facing == Facing.up) {
			//anim.GetCurrentAnimatorStateInfo(2).length
			SwordUp.SetActive(true);	
			yield return new WaitForSeconds(0.2f);
			SwordUp.SetActive(false);		
		}
		if(facing == Facing.down) {
			SwordDown.SetActive(true);
			yield return new WaitForSeconds(0.2f);
			SwordDown.SetActive(false);		
		}
		if(facing == Facing.right) {
			SwordRight.SetActive(true);
			yield return new WaitForSeconds(0.2f);	
			SwordRight.SetActive(false);		
		}
		if(facing == Facing.left) {
			SwordLeft.SetActive(true);
			yield return new WaitForSeconds(0.2f);	
			SwordLeft.SetActive(false);		
		}
		attacking = false;
		animator.SetBool("Attacking",attacking);
	}

	public void UseShield() {

	}

	public void SimulateControls() {
		if(Input.GetKey(KeyCode.W)) {
			transform.rigidbody2D.AddForce(Vector2.up * speed);
		}
		if(Input.GetKey(KeyCode.A)) {
			transform.rigidbody2D.AddForce(Vector2.right * -1 * speed);
		}
		if(Input.GetKey(KeyCode.S)) {
			transform.rigidbody2D.AddForce(Vector2.up * -1 * speed);
		}
		if(Input.GetKey(KeyCode.D)) {
			transform.rigidbody2D.AddForce(Vector2.right * speed);
		}
	}

	
	public void OnTriggerExit2D(Collider2D other) {
		
		Debug.Log("Door Collision with : " + other.gameObject.name);

	}


}
