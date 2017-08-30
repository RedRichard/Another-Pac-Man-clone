using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour {

	private static List<GameObject> vidas;

	void Start () {
		vidas = new List<GameObject> ();
		foreach (Transform child in transform)
		{
			vidas.Add (child.transform.gameObject);
			//print (vidas.Count);
		}
	}

	void Update(){
		if (vidas.Count == 0) {
			LevelManager.GameOver();
		}
	}
	
	public static void VidaPerdida(){
		Destroy (vidas[vidas.Count-1]);
		vidas.RemoveAt (vidas.Count-1);
		LevelManager.RecargarVidaMenos ();
		FantasmaCeleste.ResetPuntos ();
		FantasmaNaranja.ResetPuntos ();
		//adm.ReiniciarVidaMenosUno ();
		//print (vidas.Count);
	}
}
