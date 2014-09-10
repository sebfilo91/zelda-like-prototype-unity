using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class GameLogic : MonoBehaviour {
	public static int enemiesLeft = 0;
	public static bool roomSwitch = false;
	public GameObject block;
	public GameObject hole;
	public GameObject gebble;
	public GameObject archer;

	public GameObject topDoor;
	public GameObject botDoor;

	public GameObject blackScreen;

	private const char BLOCK_CHAR = '0';
	private const char HOLE_CHAR = 'H';
	private const char GEBBLE_CHAR = 'G';
	private const char ARCHER_CHAR = 'A';
	private const int colMax = 14;
	private const int rowMax = 9;
	private ArrayList levels = new ArrayList();
	private char[][] grid = new char[colMax][];

	private Player player;
	// Use this for initialization
	void Start () {
		//grid = readLevel("Assets/Misc/maps.txt");
		readFile("Assets/Misc/maps.txt");
		NewLevel();

		player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(player.hp <= 0) {
			//GameLost();
		}
		if(enemiesLeft == 0) {		
			topDoor.GetComponent<Door>().Open();
			if(roomSwitch) {
				StartCoroutine(LoadMapAnim());
				NewLevel();
				//Remettre character au début
				GameObject playerObject = GameObject.FindWithTag("Player");
				botDoor.GetComponent<Door>().Open();
				player.transform.position = botDoor.transform.position;
				topDoor.GetComponent<Door>().Close();	
			}
		}
	}
	

	void NewLevel() {
		int mapIndex = Random.Range(0,levels.Count-1);
		generateMap((char[][])(levels[mapIndex]));
	}

	IEnumerator LoadMapAnim() {
		blackScreen.SetActive(true);
		yield return new WaitForSeconds(1);
		blackScreen.SetActive(false);
	}

	void generateMap(char[][] tab) {
		for(int x = 0;x < tab.Length;x++) {
			for(int y = 0;y < tab[x].Length;y++) {
				if(tab[x][y] == BLOCK_CHAR) {
					Instantiate(block,new Vector3(x,y),Quaternion.identity);
				}
				if(tab[x][y] == HOLE_CHAR) {
					Instantiate(hole,new Vector3(x,y),Quaternion.identity);
				}
				if(tab[x][y] == GEBBLE_CHAR) {
					Instantiate(gebble,new Vector3(x,y),Quaternion.identity);
					enemiesLeft++;
				}
				if(tab[x][y] == ARCHER_CHAR) {
					Instantiate(archer,new Vector3(x,y),Quaternion.identity);
					enemiesLeft++;
				}
			}
		}
	}

	void readFile(string file) {
		string text = System.IO.File.ReadAllText(file);
		string[] lines = Regex.Split(text, "\n");
		for(int i = 0; i < lines.Length; i++) {
			if(lines[i][0].Equals('-')) {
				Debug.Log("niveau " + i);
				i++;
				string[] level = new string[rowMax];
				for(int j = 0; j < rowMax; j++) {
					level[j] = lines[i + j];
				}
				levels.Add(readLevel(level));
			}
		}

	}
	
	char[][] readLevel(string[] lines){
		int rows = lines.Length;
		
		char[][] levelBase = new char[colMax][];
		levelBase[0] = new char[rowMax];
		levelBase[1] = new char[rowMax];
		levelBase[2] = new char[rowMax];
		levelBase[3] = new char[rowMax];
		levelBase[4] = new char[rowMax];
		levelBase[5] = new char[rowMax];
		levelBase[6] = new char[rowMax];
		levelBase[7] = new char[rowMax];
		levelBase[8] = new char[rowMax];
		levelBase[9] = new char[rowMax];
		levelBase[10] = new char[rowMax];
		levelBase[11] = new char[rowMax];
		levelBase[12] = new char[rowMax];
		levelBase[13] = new char[rowMax];
		for (int row = 0; row < lines.Length; row++)  {
			for(int col = 0; col < lines[row].Length; col++) {
				levelBase[col][row] = lines[row][col];
			}
		}
		return levelBase;
	}


	/*
	char[][] readLevel(string file){
		string text = System.IO.File.ReadAllText(file);
		string[] lines = Regex.Split(text, "\n");
		int rows = lines.Length;
		
		char[][] levelBase = new char[colMax][];
		levelBase[0] = new char[rowMax];
		levelBase[1] = new char[rowMax];
		levelBase[2] = new char[rowMax];
		levelBase[3] = new char[rowMax];
		levelBase[4] = new char[rowMax];
		levelBase[5] = new char[rowMax];
		levelBase[6] = new char[rowMax];
		levelBase[7] = new char[rowMax];
		levelBase[8] = new char[rowMax];
		levelBase[9] = new char[rowMax];
		levelBase[10] = new char[rowMax];
		levelBase[11] = new char[rowMax];
		levelBase[12] = new char[rowMax];
		levelBase[13] = new char[rowMax];
		for (int row = 0; row < lines.Length; row++)  {
			for(int col = 0; col < lines[row].Length; col++) {
				levelBase[col][row] = lines[row][col];
			}
		}
		return levelBase;
	}*/
}
