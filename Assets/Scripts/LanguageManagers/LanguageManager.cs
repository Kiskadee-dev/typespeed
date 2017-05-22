using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
public class LanguageManager : MonoBehaviour {
	public LangC langClass;
	public LangC langInstance;
	public string Language;
	// Use this for initialization
	void Awake(){
		Language = Application.systemLanguage.ToString();
		//Language = "english";
		langClass = new LangC ();
		langInstance = langClass;
		XmlDocument xml = new XmlDocument ();
		TextAsset text = Resources.Load("dicionario1") as TextAsset;
		if(text != null){
			Debug.Log ("Carregou");
			xml.LoadXml (text.text);
			if (Language == "Portuguese") {
				langClass.LangDirect (xml, "Portuguese");
			} else {
				langClass.LangDirect (xml, "English");
			}

		}else{
		}
	}

	public string GetString(string name){
		return langInstance.GetString (name);

	}

}
