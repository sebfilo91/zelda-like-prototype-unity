using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {
	public Enemy[] enemies;

	public float X;
	public float Y;
	private float minX;
	private float minY;
	private float maxX;
	private float maxY;

	private float randomNextRespawn;
	// Use this for initialization
	void Start () {
		StartCoroutine(Respawn());
		
		minX = transform.position.x;
		minY = transform.position.x;
		maxX = minX + X;
		maxY = minY + Y;
	}
	


	IEnumerator Respawn() {
		while(true) {
			float randX = Random.Range(minX,maxX);
			float randY = Random.Range(minY,maxY);
			randomNextRespawn = Random.Range(2,5);
			TriggerRespawn(enemies[0].gameObject,new Vector2(randX,randY));

			
			yield return new WaitForSeconds(randomNextRespawn);
		}

	}

	void TriggerRespawn(GameObject obj, Vector2 pos) {
		Instantiate(obj,pos,Quaternion.identity);
	}
}
