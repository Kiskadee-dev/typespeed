using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class mainscreen : MonoBehaviour {
	LeaderBoardManager LBM;
	public Button hook1;
	public Button hook2;

	// Use this for initialization
	void Start () {
		StartCoroutine (waitsome ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator waitsome(){
		yield return new WaitForSeconds (3);
		if (hook1 != null && hook2 != null) {
			if (PlayGamesPlatform.Instance.localUser.authenticated) {
				hook1.interactable = true;
				hook2.interactable = true;
			}
		} else {
			Debug.Log ("Not authenticated, cant show");
		}
	}
}
