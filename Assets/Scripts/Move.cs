using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(1* Time.deltaTime * speed,0,0));
	}
	void OnCollisionEnter(Collision col){
		Debug.Log (col.gameObject.name);
	}
}
