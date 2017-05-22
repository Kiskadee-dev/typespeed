using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionScore : MonoBehaviour {
	public float score;
	void Awake ()
	{
		if(PlayerPrefs.HasKey("sessionscore")){
			score = PlayerPrefs.GetInt("sessionscore");
		}
		DontDestroyOnLoad (this.gameObject);
	}
}
