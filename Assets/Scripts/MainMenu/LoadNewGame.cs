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
		PlayerPrefs.SetInt ("Nivel", 0);
		PlayerPrefs.SetInt ("Vidas", 3);
		SceneManager.LoadScene (1);
	}

	public void uiLoadGame(){
		SceneManager.LoadScene (1);
	}
}
