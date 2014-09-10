using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
	public GameObject playerObject;

	public GUISkin skin;

	private CharacterController character;
	private Player player;

	private Rect buttonAttack = new Rect(0,0,50,50);
	private Rect buttonShield = new Rect(0,0,50,50);
	private Rect labelHP = new Rect(100,100,50,50);

	private int buttonOffset = 1;

	private string debugText;
	private Rect debugRect = new Rect(0,0,100,300);
	// Use this for initialization

	private bool playerLost = false;
	void Start () {
		character = playerObject.GetComponent<CharacterController>();
		player = playerObject.GetComponent<Player>();

		buttonShield.x = Screen.width - buttonShield.width;
		buttonShield.y = Screen.height - buttonShield.height - buttonOffset;
		buttonAttack.x = buttonShield.x - buttonAttack.width - buttonOffset;
		buttonAttack.y = Screen.height - buttonAttack.height - buttonOffset;
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.skin = skin;
		if(GUI.Button(buttonAttack,"Attack")) {
			StartCoroutine(character.Attack());
		}
		if(GUI.Button(buttonShield,"Shield")) {
			character.UseShield();
		}
		if(playerLost) {
			GUI.Label(new Rect(Screen.width/2,Screen.height/2,200,200),"Perdu..");
		}
		GUI.Label(labelHP,player.hp.ToString());

		DebugLog();
	}

	void DebugLog() {
		
		debugText = "";

		debugText += "acceleration : " + Input.acceleration;

		
		GUI.Label(debugRect,debugText);
	}
}
