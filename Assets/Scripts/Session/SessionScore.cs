using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionScore : MonoBehaviour {
	public float score;
	void Awake ()
	{
		ZPlayerPrefs.Initialize ("909p09k09z09A090", "090909kasdjald");
		if(ZPlayerPrefs.HasKey("sessionscore")){
			score = ZPlayerPrefs.GetInt("sessionscore");
		}
		DontDestroyOnLoad (this.gameObject);
	}
}
