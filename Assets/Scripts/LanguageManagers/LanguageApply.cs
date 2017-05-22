using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LanguageApply : MonoBehaviour {
	public LanguageManager LangManager;
	public string RequestName;
	public Text texto;
	// Use this for initialization
	void Start () {
		texto = GetComponent<Text> ();
		texto.text = LangManager.GetString (RequestName);
	}
	public void ChangeTextWithArg(string arg){
		texto = GetComponent<Text> ();
		texto.text = LangManager.GetString (RequestName + arg);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
