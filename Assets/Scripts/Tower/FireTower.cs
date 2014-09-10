using UnityEngine;
using System.Collections;

public class FireTower : Tower {
	public override void Trigger() {
		Debug.Log("fireTrigger");

		animator.SetBool("explosing",true);

		
		Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position,2f);	
		foreach(Collider2D target in targets) {
			if(target.tag == "Enemy") {
				Destroy(target.gameObject);
			}
		}
		StartCoroutine(Die());
	}
}
