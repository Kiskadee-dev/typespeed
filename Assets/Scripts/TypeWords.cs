using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TypeWords : MonoBehaviour {
	public InputField UserWrote;
	public WordCreator m_wordcreator;
	public int score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SeekAndDestroy(){
		string cache = UserWrote.text;
		Debug.Log (cache);
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
		UserWrote.text = "";
		UserWrote.ActivateInputField ();
		UserWrote.Select ();
	}
	int DestroyWord(List<GameObject> words){
		int score = 0;
		for (int i = 0;i < words.Count;i++) {
			score += words[i].GetComponent<WordTracker> ().damage;
			m_wordcreator.Palavras.Remove (words[i].GetComponent<WordTracker> ());
			Destroy (words [i]);
		}
		return score;
	}
}
