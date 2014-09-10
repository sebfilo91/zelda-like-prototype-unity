using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	protected Animator animator;
	
	void Start() {
		animator = GetComponent<Animator>();
	}

	public virtual void Trigger() {
		Debug.Log("towerTrigger");
	}
	
	protected IEnumerator Die() {
		yield return new WaitForSeconds(1.0f);
		Destroy(transform.gameObject);
	}
}
