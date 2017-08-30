using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private static Text texto;
	private static int puntuacion;
	public static int lecPunt;

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start () {
		texto = GetComponent<Text> ();
	}
	
	public static void AgregarPuntos(int puntos){
		puntuacion += puntos;
		lecPunt = puntuacion;
		texto.text = puntuacion.ToString();
	}

	public static void AgregarPuntosFantasmaMuerto(){
		puntuacion += 200*(AdministradorFantasmas.GetCantidadFantasmasMuertos());
	}

	public static int GetScore()
	{
		return lecPunt;
	}
}
