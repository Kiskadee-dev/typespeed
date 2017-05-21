using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCreator : MonoBehaviour {
	[Header("Prefabs")]
	public GameObject prefabWord;
	public GameObject prefabLimite;
	[Header("Dicionario de palavras")]
	private string dicionario = "Hello World.Python.Escada.Computador.Android.Jogo.pen drive.Terminal.Edge.Windows.Linux.Ubuntu.horizonte.abrueba.calango.tequila.tekila.mexico.eua.baranga.cacatua";
	private Vector3 camborder;
	private int PlayableAreaY1,PlayableAreaY2,PlayableAreaY3;
	public Queue<string> LevelRemaining = new Queue<string>();
	int[] playArea = {0,0,0};
	private GameObject LastWord;
	[Header("Vida e velocidade")]
	public float Health = 100;
	public int OverallSpeedBasedOnLevel;

	private Color[] cores = {
		//Color.black,
		Color.blue,
		Color.cyan,
		Color.gray,
		Color.green,
		Color.red,
		Color.magenta,
		Color.yellow,
		Color.white
	};
	[Header("Timer")]
	public float timer;
	public float timenow;
	[Header("Listas")]
	public List<WordTracker> Palavras = new List<WordTracker> ();
	[Header("Status do jogo")]
	public int PalavrasRestantes;
	public bool GameStarted;

	[Header("Status do Componente")]
	public bool ContinuaConstrucao = true;
	GameObject WordsHolder;
	// Use this for initialization
	void Start () {
		WordsHolder = (GameObject)Instantiate (prefabWord, this.transform.position, Quaternion.identity);
		WordsHolder.name = "WordsHolder";
		timenow = timer;
		camborder = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		PlayableAreaY1 = (int)camborder.y - 60;
		PlayableAreaY2 = (int)camborder.y - 120;
		PlayableAreaY3 = (int)camborder.y - PlayableAreaY2 - 50;
		playArea[0] = PlayableAreaY1;
		playArea [1] = PlayableAreaY2;
		playArea [2] = PlayableAreaY3;

		Instantiate (prefabLimite, new Vector3 (camborder.x + 25, -4, 0), Quaternion.identity);

		for (int i = 0; i < 20; i++) {
			AddNewJob (GetRandomWord ());
			PalavrasRestantes++;
		}
		GameStarted = true;

	}
	public void AddNewJob(string word){
		LevelRemaining.Enqueue (word);
	}
	string GetRandomWord(){
		string[] split = dicionario.Split ('.');
		string word = split[Random.Range (0, split.Length)];
		return word;
	}

	void GenerateWord(Vector3 PositionToSpawn,string word,int speed,bool damage = true){
		if (LastWord != null) {
			Bounds b = LastWord.GetComponent<BoxCollider> ().bounds;
			PositionToSpawn = new Vector3 (PositionToSpawn.x - Vector3.Distance(PositionToSpawn,LastWord.transform.position) - b.extents.x * 3,PositionToSpawn.y,PositionToSpawn.z);
		}
		GameObject instancia = (GameObject)Instantiate (prefabWord, PositionToSpawn, Quaternion.identity);

		instancia.AddComponent<Move> ().speed = speed;
		instancia.AddComponent<TextMesh> ().text = word;
		instancia.GetComponent<TextMesh> ().characterSize = 8;
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
		instancia.GetComponent<WordTracker> ().WordCreator = this;
		if (!damage) {
			instancia.GetComponent<WordTracker> ().damage = 0;
		} 
		LastWord = instancia;
		instancia.transform.SetParent (WordsHolder.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (ContinuaConstrucao) {
			if (timenow <= timer) {
				if (LevelRemaining.Count > 0) {
					if (PalavrasRestantes > 0) {
						GenerateWord (new Vector3 (-camborder.x - 25, playArea [Random.Range (0, playArea.Length)], 1), LevelRemaining.Dequeue (), OverallSpeedBasedOnLevel);
					} else {
						GenerateWord (new Vector3 (-camborder.x - 25, playArea [Random.Range (0, playArea.Length)], 1), LevelRemaining.Dequeue (), OverallSpeedBasedOnLevel,false);

					}
						timenow += timer;
				}
			} else {
				timenow -= Time.deltaTime;
			}
		}
	}
	public void ApplyDamage(float damage,WordTracker word){
		if (Health > 0) {
			Health -= damage;
		} else {
			Health = 0;
		}
		Palavras.Remove (word);
		Destroy (word.gameObject);
		PalavrasRestantes--;
	}
	public void OrderHalt(){
		foreach (WordTracker word in Palavras) {
			word.gameObject.GetComponent<Move> ().DoMove = false;
		}
	}
	public void OrderMove(){
		foreach (WordTracker word in Palavras) {
			word.gameObject.GetComponent<Move> ().DoMove = true;
		}
	}
}
