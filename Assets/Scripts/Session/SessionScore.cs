using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionScore : MonoBehaviour {
	public float score;
	void Awake ()
	{
		DontDestroyOnLoad (this.gameObject);
	}
}
