using UnityEngine;
using System.Collections;

public class ShieldTower : Tower {
	Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
	}

	public override void Trigger() {
		Debug.Log("shieldTrigger");



		animator.SetBool("explosing",true);

		Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position,2f);	
		foreach(Collider2D target in targets) {
			if(target.tag == "Enemy") {

			}
		}
		StartCoroutine(Die());
	}

	
}
