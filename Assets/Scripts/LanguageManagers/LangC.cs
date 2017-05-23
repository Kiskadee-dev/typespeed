using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LangC{
	
	Hashtable Strings;
	public void Lang(string path, string language){
		setLanguage (path, language);
	}
	public void setLanguage(string path,string language){
		XmlDocument xml = new XmlDocument ();
		xml.Load (path);
		Strings = new Hashtable ();
		XmlElement element = xml.DocumentElement[language];
		if (element != null) {
			IEnumerator elemeNum = element.GetEnumerator ();
			while (elemeNum.MoveNext ()) {
				XmlElement xmlItem = (XmlElement)elemeNum.Current;
				Strings.Add (xmlItem.GetAttribute ("name"), xmlItem.InnerText);
			}
		} else {
			Debug.LogError("The specified language does not exist: " + language);

		}
	}
	public void LangDirect(XmlDocument doc, string language){
		setLanguageDirect (doc, language);
	}
	public void setLanguageDirect(XmlDocument doc,string language){
		XmlDocument xml = doc;
		//xml.Load (doc);
		Strings = new Hashtable ();
		XmlElement element = xml.DocumentElement[language];
		if (element != null) {
			IEnumerator elemeNum = element.GetEnumerator ();
			while (elemeNum.MoveNext ()) {
				XmlElement xmlItem = (XmlElement)elemeNum.Current;
				Strings.Add (xmlItem.GetAttribute ("name"), xmlItem.InnerText);
			}
		} else {
			Debug.LogError("The specified language does not exist: " + language);

		}
	}

	public string GetString(string name){
		if (!Strings.ContainsKey (name)) {
			Debug.LogError ("The specified string does not exist: " + name);
			return "";
		} else {
			return (string)Strings[name];
			}
	}


}
