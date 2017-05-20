using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTracker : MonoBehaviour {
	public int damage;
	public string m_word;
	public WordCreator WordCreator;

	public void ApplyDamage(){
		WordCreator.ApplyDamage (damage, this);
	}
}
