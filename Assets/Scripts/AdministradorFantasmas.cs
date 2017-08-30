using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorFantasmas : MonoBehaviour {

	private static Fantasma[] fantasmas;
	private Fantasma ghostAux;
	private static bool fantasmasAsustados;
	private static float tiempoAsustar;
	private static int cantidadFantasmasMuertos;
	private static bool pausaAntesDeComenzar;

	void Start () {
		fantasmas = GetComponentsInChildren<Fantasma> ();
	}
	
	void Update () {
		if (pausaAntesDeComenzar && Input.anyKeyDown) {
			Time.timeScale = 1f;
		}
		foreach (Fantasma ghost in fantasmas) {
			ghost.MovementMode ();
		}
		if (fantasmasAsustados) {
			//tiempoAsustar = Time.time;
			//Debug.Log (Time.time-tiempoAsustar);
			if ((int)(Time.time-tiempoAsustar) > 8) {
				//Debug.Log ("Cambio");
				QuitarSusto ();
			}
		}
	}

	/*public void Asustar(){
		tiempoAsustar = Time.time;
		fantasmasAsustados = true;
		foreach (Fantasma ghost in fantasmas) {
			ghost.Afraid ();
		}
	}*/

	public void QuitarSusto(){
		tiempoAsustar = 0;
		fantasmasAsustados = false;
		foreach (Fantasma ghost in fantasmas) {
			if (ghost.GetIsAfraid () && !ghost.GetEnCaminoPuntoInicial()) {
				ghost.NotAfraid ();
			}
		}
		cantidadFantasmasMuertos = 0;
	}

	public static void AumentarFantasmasMuertos(){
		cantidadFantasmasMuertos++;
	}

	public static void ReiniciarPosiciones(){
		pausaAntesDeComenzar = true;
		Time.timeScale = 0f;
		foreach (Fantasma ghost in fantasmas) {
			ghost.ReiniciarPosicion ();
			ghost.RegresarObjetivoOriginal ();
		}
	}

	public static void CambiarAModoAfraid(){
		tiempoAsustar = Time.time;
		fantasmasAsustados = true;
		foreach (Fantasma ghost in fantasmas) {
			ghost.Afraid ();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Fantasma") {
			ghostAux = col.GetComponent<Fantasma> ();
			ghostAux.NotAfraid ();

			ghostAux.MueveAbajo ();
			if (ghostAux.GetIsAfraid ()) {
				ghostAux.RegresarObjetivoOriginal ();
				ghostAux.Afraid ();
				//ghostAux.ReiniciarPosicion();
				//ghostAux.NotAfraid();
				ghostAux.MueveAbajo ();
			}
		}
	}

	public static int GetCantidadFantasmasMuertos(){
		return cantidadFantasmasMuertos;
	}
}
