using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNewGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void uiLoadNewGame(){
		ZPlayerPrefs.SetInt ( "Nivel", 0);
		ZPlayerPrefs.SetInt ("Vidas", 3);
		ZPlayerPrefs.SetString ("data", "empty.");
		SessionScore score = GameObject.Find ("sessionScoreInstance").GetComponent<SessionScore> ();
		score.score = 0;
		SceneManager.LoadScene (1);
	}

	public void uiLoadGame(){
		SceneManager.LoadScene (1);
	}
}
