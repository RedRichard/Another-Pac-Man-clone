using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaNaranja : Fantasma {

	//private Vector3 direccion;
	private int posAux;
	//private InterseccionCruz interseccionCruzAux;
	public static int puntos;
	float puntosSal;
	float puntosSum;
	public static int bloqMov=0;
	public static bool movLibre=false;
	public static int bloqCont=0;
	float contador=0.0f;
	public float contar1=1.0f;
	public GameObject player;
	public GameObject fantasma;
	float distancia;

	public override void Start () {
		base.Start ();
		//colorOriginal = new Color (255, 102, 0);
		Scatter ();
		SetComponentPosX(transform.position.x);
		SetComponentPosY(transform.position.y);
		SetComponentHorizontal (true);
		SetComponentVertical (false);
		SetColliderFantasma(GetComponent<CircleCollider2D> ());
		posicionOriginal = this.transform.position;
	}

	override protected void Update (){
		puntosSal = (float)puntos + puntosSum;
		if (puntosSal >= 150) {
			if (bloqMov == 0) {

				MueveIzquierda ();
				//print("El fantasma naranja se debe mover izq");
				bloqMov = 1;
			} else {
				Mover ();
				//print ("debe estarse moviendo");
				if (bloqCont == 0) {
					contador += Time.deltaTime;
				}
				if (contador >= contar1) {
					MueveArriba ();
					//print ("Mover arriba");
					movLibre = true;
					bloqCont = 1;
					contador = 0;
				}

				if (movLibre) {
					
					direccion = (GetObjetivo().transform.position - this.transform.position - (new Vector3 (0.5f,0.5f,0f))).normalized ;
				}


			}
		} 
		else if(puntosSal<150) {
			DentroCasaFN ();
			puntosSum += 0.15f;
		}

	}

	/*public void Girar(){
		if (GetComponentHorizontal ()) {

			//print ("Intentando giro horizontal");
			if (direccion.y > 0) {
				//print (direccion.x.ToString ());
				MueveArriba ();

			} else if (direccion.y < 0) {
				//print (direccion.x.ToString ());
				MueveAbajo ();

			} 
		} else if(GetComponentVertical()){
			//print ("Intentando giro vertical");
			if (direccion.x > 0) {
				//print ("Derecha");
				MueveDerecha ();

			} else if (direccion.x < 0) {
				//print ("Izquierda");
				MueveIzquierda ();
			} 
		}
	}*/

	/*void OnTriggerEnter2D(Collider2D col){
		//print ("El fantasma rojo detecta una colision");
		if (col.gameObject.tag == "Muro") {
			//print ("Colision con Muro");
			//interseccionCruzAux.SetChildFalse ();
			Girar ();
		} else if (col.gameObject.tag == "MuroInterseccion") {
			interseccionCruzAux.SetChildFalse ();
			Girar ();
		} else if (col.gameObject.tag == "Abajo") {
			MueveAbajo ();
		} else if (col.gameObject.tag == "Arriba") {
			MueveArriba ();
		} else if (col.gameObject.tag == "Derecha") {
			MueveDerecha ();
		} else if (col.gameObject.tag == "Izquierda") {
			MueveIzquierda ();
		} else if (col.gameObject.tag == "Player" && !isAfraid) {
			//print ("Gotcha");
			Vidas.VidaPerdida ();
		} else if (col.gameObject.tag == "AuxGiroCruz") {
			interseccionCruzAux = col.gameObject.GetComponent<InterseccionCruz> ();
		}
	}*/

	void CamMov()
	{
		distancia = Vector3.Distance (fantasma.transform.position, player.transform.position);
		//print ("Disctancia: " + distancia);
		if (distancia <= 8) {
			Chase ();
		} else {
			MovementMode2 ();

		}
	}
		
	override public void ReiniciarPosicion(){
		base.ReiniciarPosicion ();
		MueveArriba ();
	}
	public static void ContarPuntos(int suma){
		puntos+= suma;
	}

	public static void ResetPuntos()
	{
		puntos = 0;
		bloqMov = 0;
		bloqCont = 0;
		movLibre = false;
	}
}
