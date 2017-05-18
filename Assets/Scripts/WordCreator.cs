using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCreator : MonoBehaviour {
	public GameObject prefabWord;
	public GameObject prefabLimite;
	private string dicionario = "Hello World.Terminal.Edge.Windows.Linux.Ubuntu.horizonte.abrueba.calango.tequila.tekila.mexico.eua.baranga.cacatua";
	public Vector3 camborder;
	public int PlayableAreaY1,PlayableAreaY2,PlayableAreaY3;
	public Queue<string> LevelRemaining = new Queue<string>();
	int[] playArea = {0,0,0};
	public GameObject LastWord;
	private Color[] cores = {
		Color.black,
		Color.blue,
		Color.cyan,
		Color.gray,
		Color.green,
		Color.red,
		Color.magenta,
		Color.yellow,
		Color.white
	};
	public float timer,timenow;
	public List<WordTracker> Palavras = new List<WordTracker> ();
	// Use this for initialization
	void Start () {
		timenow = timer;
		camborder = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		PlayableAreaY1 = (int)camborder.y - 60;
		PlayableAreaY2 = (int)camborder.y - 120;
		PlayableAreaY3 = (int)camborder.y - PlayableAreaY2 - 50;
		playArea[0] = PlayableAreaY1;
		playArea [1] = PlayableAreaY2;
		playArea [2] = PlayableAreaY3;

		GameObject Limite = (GameObject)Instantiate (prefabLimite, new Vector3 (camborder.x + 25, -4, 0), Quaternion.identity);

		for (int i = 0; i < 20; i++) {
			AddNewJob (GetRandomWord ());
		}
	}
	void AddNewJob(string word){
		LevelRemaining.Enqueue (word);
	}
	string GetRandomWord(){
		string[] split = dicionario.Split ('.');
		string word = split[Random.Range (0, split.Length)];
		return word;
	}

	void GenerateWord(Vector3 PositionToSpawn,string word,int speed){
		if (LastWord != null) {
			Bounds b = LastWord.GetComponent<BoxCollider> ().bounds;
			PositionToSpawn = new Vector3 (PositionToSpawn.x - Vector3.Distance(PositionToSpawn,LastWord.transform.position) - b.extents.x * 3,PositionToSpawn.y,PositionToSpawn.z);
		}
		GameObject instancia = (GameObject)Instantiate (prefabWord, PositionToSpawn, Quaternion.identity);

		instancia.AddComponent<Move> ().speed = speed;
		instancia.AddComponent<TextMesh> ().text = GetRandomWord();
		instancia.GetComponent<TextMesh> ().characterSize = 14;
		instancia.GetComponent<TextMesh> ().anchor = TextAnchor.MiddleCenter;
		instancia.GetComponent<TextMesh> ().alignment = TextAlignment.Center;
		instancia.AddComponent<MeshCollider> ();
		instancia.AddComponent<BoxCollider> ();
		instancia.AddComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		instancia.GetComponent<Rigidbody> ().useGravity = false;
		instancia.GetComponent<TextMesh> ().color = cores [Random.Range (0, cores.Length)];
		Palavras.Add (instancia.AddComponent<WordTracker> ());
		instancia.GetComponent<WordTracker> ().damage = 10;
		instancia.GetComponent<WordTracker> ().m_word = instancia.GetComponent<TextMesh> ().text;
		LastWord = instancia;
	}
	
	// Update is called once per frame
	void Update () {
		if (timenow <= timer) {
			if (LevelRemaining.Count > 0) {
				GenerateWord (new Vector3 (-camborder.x - 25, playArea [Random.Range (0, playArea.Length)], 1), LevelRemaining.Dequeue (), 20);
				timenow += timer;
			}
		} else {
			timenow -= Time.deltaTime;
		}
	}
}
