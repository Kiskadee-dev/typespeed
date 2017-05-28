using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;
public class GameManager : MonoBehaviour {
	//Esta instância do GameManager não é persistente e só verifica a condição de vitória e atribui dificuldade;
	public int Vidas;
	public int Nivel;
	public int Velocidade;
	public WordCreator m_WordCreator;
	public TypeWords type;
	public bool halt;
	public Text ui_Level;
	public GameObject ui_Paused;
	public bool DEBUG;
	public bool DoPause;
	public LanguageManager LM;
	public string nivelt;
	public conquistas GPGSconquistas;
	void Awake(){
		LM = GameObject.Find ("LanguageManager").GetComponent<LanguageManager> ();
		if (DEBUG) {
			ZPlayerPrefs.DeleteAll();
		}
		Velocidade = 10;
		if (ZPlayerPrefs.HasKey ("Vidas") && ZPlayerPrefs.HasKey("Nivel")) {
			Vidas = ZPlayerPrefs.GetInt ("Vidas");
			Nivel = ZPlayerPrefs.GetInt ("Nivel");

			}		
		else {
			ZPlayerPrefs.SetInt ("Vidas", 3);
			ZPlayerPrefs.SetInt ("Nivel", 0);
			Vidas = 3;
			Nivel = 0;
						
		}

		for (int i = 0; i < Nivel; i++) {
			if (i != 0) {
				Velocidade += 2;
			}
		}

		m_WordCreator.OverallSpeedBasedOnLevel = Velocidade;
	}


	void Start () {
		nivelt = LM.GetString ("level");

		ui_Level.text = nivelt + "0";

		Analytics.CustomEvent ("Jogando");
		Analytics.CustomEvent ("NivelDinamico:", new Dictionary<string,object> {
			{ "Nivel: ",Nivel }

		});
	}
	// Update is called once per frame
	void Update () {
		ui_Level.text = nivelt+Nivel.ToString ();
		if (!halt) {
			if (m_WordCreator.GameStarted) {
				if (m_WordCreator.PalavrasRestantes == 0) {
					if (m_WordCreator.Health > 0) {
						Vence ();
						halt = true;
						m_WordCreator.OrderHalt ();
					} else {
						if (m_WordCreator.Health <= 0) {
							Perde ();
							halt = false;
							m_WordCreator.OrderHalt ();

						}
					}
				}
				if (m_WordCreator.Health <= 0) {
					Perde ();
					halt = true;
				}
			}
		}
	}
	void Vence(){
		//m_WordCreator.LevelRemaining.Clear ();
		//m_WordCreator.AddNewJob ("Level Increased");
		Nivel++;
		Analytics.CustomEvent ("Leveled up:", new Dictionary<string,object> {
			{ "Nivel: ",Nivel }

		});
		ZPlayerPrefs.SetInt ("Nivel", Nivel);
		SessionScore session = GameObject.Find ("sessionScoreInstance").GetComponent<SessionScore> ();
		session.score += type.score;
		ZPlayerPrefs.SetInt ("sessionscore", (int)session.score);
		GPGSconquistas.ConquestTyperBorn ((int)session.score);
		if (Nivel >= 10) {
			GPGSconquistas.ConquestTyperSpeedster ((int)session.score);
			if (Nivel >= 15) {
				GPGSconquistas.ConquestTyperGood ((int)session.score);
				if (Nivel >= 20) {
					GPGSconquistas.ConquestTyperProfessional ((int)session.score);
				}
			}
		}
		GPGSconquistas.UpdateGlobalRanking ((int)session.score);
		StartCoroutine(SwitchLevel (1, 4));

	}
	void Perde(){
		if (Vidas > 0) {
			//Vidas--; //Sem game over.
			ZPlayerPrefs.SetInt ("Vidas", Vidas);
			StartCoroutine(SwitchLevel (1, 4));
		} else {
			//Vidas = 3;
			//Nivel = 0;
			//PlayerPrefs.SetInt ("Vidas", Vidas);
			//PlayerPrefs.SetInt ("Nivel", Nivel);
			StartCoroutine(SwitchLevel (2, 4));

		}
	}
	IEnumerator SwitchLevel(int scene,float WaitTime){
		yield return new WaitForSeconds (WaitTime);
		SceneManager.LoadScene (scene);
	}

	void OrderPause(){
		m_WordCreator.OrderHalt ();
		m_WordCreator.ContinuaConstrucao = false;
		type.DoActive = false;
	}
	void OrderUpause(){
		m_WordCreator.OrderMove ();
		m_WordCreator.ContinuaConstrucao = true;
		type.DoActive = true;
	}
	public void ui_Pause(){
		DoPause = !DoPause;
		if (DoPause) {
			OrderPause ();
			ui_Paused.SetActive (true);
		} else {
			OrderUpause ();
			ui_Paused.SetActive (false);
		}
	}
	public void RestartLevel(){
		SceneManager.LoadScene (1);
	}
	public void BackToMainMenu(){
		SceneManager.LoadScene (0);
	}
}
