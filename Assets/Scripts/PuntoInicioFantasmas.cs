using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoInicioFantasmas : MonoBehaviour {

	private Fantasma ghostAux;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Fantasma") {
			ghostAux = col.GetComponent<Fantasma> ();
			if (ghostAux.GetIsAfraid () && ghostAux.GetEnCaminoPuntoInicial()) {
				ghostAux.MueveAbajo ();
			}
		}
	}
}
