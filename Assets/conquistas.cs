using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System;
public class conquistas : MonoBehaviour {

	public void ConquestTyperBorn(int points){
		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ReportProgress (typespeed.GPGSIds.achievement_a_typer_has_born,points, (bool success) => {
				Debug.Log ("Sucesso? typerHasBorn" + success);
			});
		}

	}
	public void ConquestTyperSpeedster(int points){
		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ReportProgress (typespeed.GPGSIds.achievement_speedster,points, (bool success) => {
				Debug.Log ("Sucesso? typesSpeedster" + success);
			});
		}

	}
	public void ConquestTyperGood(int points){
		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ReportProgress (typespeed.GPGSIds.achievement_good_typer,points, (bool success) => {
				Debug.Log ("Sucesso? typerGood" + success);
			});
		}

	}
	public void ConquestTyperProfessional(int points){
		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ReportProgress (typespeed.GPGSIds.achievement_professional_typer,points, (bool success) => {
				Debug.Log ("Sucesso? typerProfessional" + success);
			});
		}

	}
	public void UpdateGlobalRanking(int score){
		if (PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.ReportScore (score, typespeed.GPGSIds.leaderboard_global_score, (bool sucess) => {
				Debug.Log ("Was the global score updated?" + sucess);
			});
		}
	}
	public void unlockalldebug(){
		ConquestTyperBorn (1);
		ConquestTyperGood (1);
		ConquestTyperProfessional (1);
		ConquestTyperSpeedster (1);
	}

}

