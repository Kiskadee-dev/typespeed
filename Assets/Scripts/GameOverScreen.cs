using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Vidas", 3);
	}
	
	public void MainMenu(){
		SceneManager.LoadScene (0);
	}
	public void SameLevel(){
		SceneManager.LoadScene (1);
	}
}
