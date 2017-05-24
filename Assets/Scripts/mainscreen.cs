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
	public Button hook3NewGame;
	public Button hook4LoadGame;
	bool init;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!init) {
			if (Social.localUser.authenticated) {
				StartCoroutine (waitsome ());
				init = true;
			}
		}
		if (!Social.localUser.authenticated) {
			hook1.interactable = false;
			hook2.interactable = false;
			hook3NewGame.interactable = false;
			hook4LoadGame.interactable = false;
		}
	}
	IEnumerator waitsome(){
		if (hook1 != null && hook2 != null) {
			if (PlayGamesPlatform.Instance.localUser.authenticated) {
				hook1.interactable = true;
				hook2.interactable = true;
				hook3NewGame.interactable = true;
				hook4LoadGame.interactable = true;

			}
		} else {
			Debug.Log ("Not authenticated, cant show");
		}
		yield break;
	}
}
