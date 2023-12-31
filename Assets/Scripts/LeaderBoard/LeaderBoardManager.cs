﻿using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
public class LeaderBoardManager : MonoBehaviour
{
	#region PUBLIC_VAR
	public string leaderboard;
	#endregion
	#region DEFAULT_UNITY_CALLBACKS
	void Start ()
	{
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;

		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate ();
		if (!PlayGamesPlatform.Instance.localUser.authenticated) {
			LogIn ();
		}
	}
	#endregion
	#region BUTTON_CALLBACKS
	/// <summary>
	/// Login In Into Your Google+ Account
	/// </summary>
	public void LogIn ()
	{
		Social.localUser.Authenticate ((bool success) =>
			{
				if (success) {
					Debug.Log ("Login Sucess");
					Debug.Log(Social.localUser.userName.ToString());
				} else {
					Debug.Log ("Login failed");
				}
			});
	}
	/// <summary>
	/// Shows All Available Leaderborad
	/// </summary>
	public void OnShowLeaderBoard ()
	{
		//        Social.ShowLeaderboardUI (); // Show all leaderboard
		//((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (leaderboard); // Show current (Active) leaderboard
		PlayGamesPlatform.Instance.ShowLeaderboardUI();
	}
	/// <summary>
	/// Adds Score To leader board
	/// </summary>
	public void OnAddScoreToLeaderBorad ()
	{
		if (Social.localUser.authenticated) {
			Social.ReportScore (100, leaderboard, (bool success) =>
				{
					if (success) {
						Debug.Log ("Update Score Success");

					} else {
						Debug.Log ("Update Score Fail");
					}
				});
		}
	}
	public void OnShowAchievements(){
		if (PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowAchievementsUI ();
		} else {
			Debug.Log ("Cant show, user not signed in ");
		}
	}
	/// <summary>
	/// On Logout of your Google+ Account
	/// </summary>
	public void OnLogOut ()
	{
		((PlayGamesPlatform)Social.Active).SignOut ();
	}
	#endregion
}
