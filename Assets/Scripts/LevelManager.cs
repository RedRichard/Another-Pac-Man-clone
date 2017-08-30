using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager: MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		if (Input.anyKeyDown){
			Time.timeScale = 1f;
		}
	}

	public void CargarNivel(string nombreNivel){
		SceneManager.LoadScene (nombreNivel, LoadSceneMode.Single);
		//nombreUltimaEscenaCargada = nombreNivel;
		if (nombreNivel == "Nivel") {
			Time.timeScale = 0f;
		}
	}

	public void Salir(){
		Application.Quit ();
	}

	public static void GameOver(){
		SceneManager.LoadScene ("GameOver", LoadSceneMode.Single);
	}

	public static void RecargarVidaMenos(){
		AdministradorFantasmas.ReiniciarPosiciones ();
	}

	public void SiguienteNivel(){
		print ("Entra");
		AdministradorFantasmas.ReiniciarPosiciones ();
		PacMan.thisPlayer.ReiniciarPosicion ();
		//Instantiate (puntosPacman);
	}
}
