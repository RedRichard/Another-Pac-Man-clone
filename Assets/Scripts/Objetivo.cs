using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			print ("Se deben agregar puntos");
			/*Score.AgregarPuntos (10);
			Destroy (col.gameObject);*/
		}
	}
}
