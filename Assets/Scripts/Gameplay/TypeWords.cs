using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TypeWords : MonoBehaviour {
	public InputField UserWrote;
	public Text ui_Score;
	public Text ui_PalavrasRestantes;
	public Text ui_Health;
	public WordCreator m_wordcreator;
	public int score;
	public bool DoActive = true;
	public LanguageManager LM;
	public string health;
	public string pontos;
	public string palavrasRestantes;
	// Use this for initialization
	void Awake(){
		LM = GameObject.Find ("LanguageManager").GetComponent<LanguageManager> ();
		health = LM.GetString ("health");
		pontos = LM.GetString ("score");
		palavrasRestantes = LM.GetString ("remainingwords");
	}
	void Start () {
		//ui_Score.text = "Score: 0";
		if (DoActive) {
			UserWrote.ActivateInputField ();
			UserWrote.Select ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		ui_PalavrasRestantes.text = palavrasRestantes + m_wordcreator.PalavrasRestantes.ToString ();
		ui_Health.text =  health + m_wordcreator.Health.ToString();
	}

	public void SeekAndDestroy(){
		if (DoActive) {
			string cache = UserWrote.text.ToLower();
			//copy list
			List<WordTracker> WordTracker = new List<WordTracker> ();
			WordTracker.AddRange (m_wordcreator.Palavras);
			List<GameObject> FoundWords = new List<GameObject> ();
			foreach (WordTracker word in WordTracker) {
				if (word.m_word == cache) {
					FoundWords.Add (word.gameObject);
				}
			}
			if (FoundWords.Count > 0) {
				score += DestroyWord (FoundWords);
			}
			if (UserWrote.text != "") {
				UserWrote.text = "";
				UserWrote.ActivateInputField ();
				UserWrote.Select ();
			}
			ui_Score.text = pontos + score.ToString ();
		}
	}
	int DestroyWord(List<GameObject> words){
		int score = 0;
		for (int i = 0;i < words.Count;i++) {
			score += words[i].GetComponent<WordTracker> ().damage;
			m_wordcreator.Palavras.Remove (words[i].GetComponent<WordTracker> ());
			Destroy (words [i]);
			m_wordcreator.PalavrasRestantes--;
		}
		return score;
	}
}
