using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SessionScoreText : MonoBehaviour {
	Text texto;
	public LanguageManager LM;
	public GameObject sessionScore;
	public SessionScore sessionScoreInstance;

	void Start () {
		GameObject obj = GameObject.Find ("sessionScoreInstance");
		if (obj != null) {
			sessionScoreInstance = obj.GetComponent<SessionScore> ();
		} else {
			GameObject obji = (GameObject)Instantiate (sessionScore, this.transform.position, Quaternion.identity);
			obji.name = "sessionScoreInstance";
			sessionScoreInstance = obji.GetComponent<SessionScore> ();
		}
		texto = this.GetComponent<Text> ();
		texto.text = LM.GetString ("sessionscore") + sessionScoreInstance.score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
