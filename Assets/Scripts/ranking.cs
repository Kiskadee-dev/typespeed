using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranking : MonoBehaviour {
	public LeaderBoardManager LBM;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Clicked(){
		LBM.OnShowLeaderBoard ();
}
	public void Achievements(){
		LBM.OnShowAchievements ();
	}
}
