using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaRojo : Fantasma {

	//private Vector3 direccion;
	private int posAux;
	//private InterseccionCruz interseccionCruzAux;

	public override void Start () {
		base.Start ();
		//colorOriginal = new Color (255, 0, 0);
		SetComponentPosX(transform.position.x);
		SetComponentPosY(transform.position.y);
		SetComponentHorizontal (true);
		SetComponentVertical (false);
		SetColliderFantasma(GetComponent<CircleCollider2D> ());
		MovementMode ();
		MueveDerecha ();
		posicionOriginal = this.transform.position;
	}

	/*void Update (){
		Mover ();
		//MovementMode ();
		//Afraid();
		direccion = (GetObjetivo().transform.position - this.transform.position - (new Vector3 (0.5f,0.5f,0f))).normalized ;
	}*/

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

	override public void ReiniciarPosicion(){
		base.ReiniciarPosicion ();
		MueveDerecha ();
	}
}
