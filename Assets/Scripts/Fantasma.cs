using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma : MonoBehaviour {
	public int speed;
	public GameObject jugadorObjetivo;
	public GameObject scatterObjetivo;
	public GameObject scatterObjetivo2;
	public GameObject scatterObjetivo3;
	public GameObject scatterObjetivo4;
	public int velocidadAfraid;
	public int velocidadRegresoInicio;
	private GameObject objetivo;
	protected Animator anim;
	private float posX;
	private float posY;
	private float valY;
	private float valY2;
	private int cont=0;
	private int bloq=0;

	private bool horizontal;
	private bool vertical;
	private Vector2 direccionMov;
	private float tiempoModosMov;
	private CircleCollider2D colliderFantasma;
	protected Vector2 posicionOriginal;
	protected bool isAfraid;
	//protected Color colorOriginal;
	//protected SpriteRenderer spriteRend;
	protected int speedOriginal;
	protected InterseccionCruz interseccionCruzAux;
	protected Vector3 direccion;
	protected bool enCaminoPuntoInicial;
	protected bool canBeAfraid;
	protected bool goingUp;
	protected bool goingDown;
	protected bool goingRight;
	protected bool goingLeft;
	protected bool posicionReiniciada;
	protected int marcadorMovMode;
	public GameObject puntoInicio;

	public virtual void Start (){
		//spriteRend = GetComponent<SpriteRenderer> ();
		speedOriginal = speed;
		canBeAfraid = true;
		anim = GetComponent<Animator> ();
	}

	protected virtual void Update(){
		Mover ();
		direccion = (objetivo.transform.position - this.transform.position - (new Vector3 (0.5f, 0.5f, 0f))).normalized;
		print (objetivo.name);
	}

	public void Mover () {
		transform.Translate (direccionMov * speed * Time.deltaTime);
	}

	public void MueveArriba(){
		colliderFantasma.offset = new Vector2 (0.5f, 0.85f);
		direccionMov = Vector2.up;
		AjustePosicion ();
		vertical = true;
		horizontal = false;
		goingUp = CambiarMarcadorDireccion ();
		//GetComponent<CircleCollider2D> ().offset = new Vector2 (0.5f, 0.75f);
	}

	public void MueveAbajo(){
		colliderFantasma.offset = new Vector2 (0.5f, 0.15f);
		direccionMov = Vector2.down;
		AjustePosicion ();
		vertical = true;
		horizontal = false;
		goingDown = CambiarMarcadorDireccion ();
		//GetComponent<CircleCollider2D> ().offset = new Vector2 (0.5f, 0.25f);
	}

	public void MueveDerecha(){
		colliderFantasma.offset = new Vector2 (0.85f, 0.5f);
		direccionMov = Vector2.right;
		AjustePosicion ();
		vertical = false;
		horizontal = true;
		goingRight = CambiarMarcadorDireccion ();
	}

	public void MueveIzquierda(){
		colliderFantasma.offset = new Vector2 (0.15f, 0.5f);
		direccionMov = Vector2.left;
		AjustePosicion ();
		vertical = false;
		horizontal = true;
		goingLeft = CambiarMarcadorDireccion ();
	}

	protected virtual bool CambiarMarcadorDireccion(){
		goingDown = false;
		goingLeft = false;
		goingRight = false;
		goingUp = false;
		return true;
	}

	public void AjustePosicion(){
		posX = Mathf.RoundToInt(transform.position.x);
		posY = Mathf.RoundToInt(transform.position.y);
		transform.position = new Vector3 (posX, posY, 0f);
	}

	public bool GetComponentHorizontal(){
		return horizontal;
	}

	public bool GetComponentVertical(){
		return vertical;
	}

	public void SetComponentHorizontal(bool seleccion){
		horizontal = seleccion;
	}

	public void SetComponentVertical(bool seleccion){
		vertical = seleccion;
	}

	public float GetComponentPosX(){
		return posX;
	}

	public float GetComponentPosY(){
		return posY;
	}

	public void SetComponentPosX(float seleccion){
		posX = seleccion;
	}

	public void SetComponentPosY(float seleccion){
		posY = seleccion;
	}

	public void SetDireccionMov(Vector2 seleccion){
		direccionMov = seleccion;
	}

	public Vector2 GetDireccionMov(){
		return direccionMov;
	}

	public void Scatter(){
		objetivo = scatterObjetivo;
		//print ("Scatter");
	}
	public void Scatter2(){
		objetivo = scatterObjetivo2;
		//print ("Scatter2");
	}

	public void Scatter3(){
		objetivo = scatterObjetivo3;
		//print ("Scatter3");
	}

	public void Scatter4(){
		objetivo = scatterObjetivo4;
		//print ("Scatter4");
	}
	public void Chase(){
		objetivo = jugadorObjetivo;
		//print ("Chase");
	}

	public virtual void Afraid(){
		if (canBeAfraid) {
			//direccionMov = direccionMov * (-1);
			/*if (isAfraid) {
				speed = speedOriginal;
				isAfraid = false;
				spriteRend.color = colorOriginal;
			} else {
				InvertirDireccion();
				speed = velocidadAfraid;
				isAfraid = true;
				spriteRend.color = Color.gray;
			}*/
			if (!isAfraid) {
				InvertirDireccion();
				speed = velocidadAfraid;
				isAfraid = true;
				anim.SetBool ("Afraid", true);
				anim.SetBool ("Regresando",false);
				//spriteRend.color = Color.gray;
			}
		}
	}
	//Fin de la conversación de chat
	//Escribe un mensaje...

	public virtual void InvertirDireccion(){
		//direccionMov = direccionMov * (-1);
		//Debug.Log ("Entra");
		if (goingLeft) {
			MueveDerecha ();
			//colliderFantasma.offset = new Vector2 (0.5f, 0.85f);
		} else if (goingRight) {
			//Debug.Log ("Entra");
			MueveIzquierda ();
			//colliderFantasma.offset = new Vector2 (0.5f, 0.15f);
		} else if (goingUp) {
			MueveAbajo ();
			//colliderFantasma.offset = new Vector2 (0.15f, 0.5f);
		} else if (goingDown) {
			MueveArriba ();			//colliderFantasma.offset = new Vector2 (0.85f, 0.5f);
		}
	}

	public virtual void NotAfraid(){
		tiempoModosMov = Time.time;
		if (isAfraid) {
			speed = speedOriginal;
			isAfraid = false;
			//direccionMov = direccionMov * (-1);
			anim.SetBool ("Afraid", false);
			anim.SetBool ("Regresando",true);
			//spriteRend.color = colorOriginal;
			enCaminoPuntoInicial = false;
		}
	}

	public virtual bool GetIsAfraid(){
		return isAfraid;
	}

	public virtual void RegresarPuntoInicio(){
		//direccionMov = direccionMov * (-1);
		anim.SetBool ("Afraid", false);
		anim.SetTrigger ("Comido");
		speed = velocidadRegresoInicio;
		enCaminoPuntoInicial = true;
		objetivo = puntoInicio;
	}

	public virtual bool GetEnCaminoPuntoInicial(){
		return enCaminoPuntoInicial;
	}
		
	public void MovementMode(){
		//print (tiempoModosMov);
		//tiempoModosMov = Time.time;
		//print(Time.time - tiempoModosMov);
		if ((int)(Time.time - tiempoModosMov) <= 7 && !isAfraid && marcadorMovMode < 2) {
			//print ("scatter");
			Scatter ();
			//tiempoModosMov = Time.time;
		} else if ((int)(Time.time - tiempoModosMov) <= 5 && !isAfraid && marcadorMovMode < 4) {
			//print ("scatter");
			Scatter ();
			//tiempoModosMov = Time.time;
		} else if ((int)(Time.time - tiempoModosMov) > 7 && !isAfraid && marcadorMovMode < 2){
			//print ("chase");
			Chase ();
			//tiempoModosMov = Time.time;
		} else if ((int)(Time.time - tiempoModosMov) > 5 && !isAfraid && marcadorMovMode < 4){
			//print ("chase");
			Chase ();
			//tiempoModosMov = Time.time;
		}else if ((int)(Time.time - tiempoModosMov) <= 7 && !isAfraid && marcadorMovMode >= 4) {
			Chase ();
			//tiempoModosMov = Time.time;
		}
		if ((int)(Time.time - tiempoModosMov) >= 27 && !isAfraid) {
			tiempoModosMov = Time.time;
			marcadorMovMode += 1;
			print (marcadorMovMode);
		}
		if (posicionReiniciada) {
			marcadorMovMode = 0;
			tiempoModosMov = Time.time;
			posicionReiniciada = false;
		}
		if (enCaminoPuntoInicial) {
			//print ("Reiniciar");
			objetivo = puntoInicio;
			RegresarPuntoInicio ();
		}
	}

	public void SetColliderFantasma(CircleCollider2D col){
		colliderFantasma = col;
	}

	public GameObject GetObjetivo(){
		return objetivo;
	}

	public void MovementMode2(){


		if ((int)tiempoModosMov <= 7) {
			Scatter ();
			tiempoModosMov = Time.time;
		} else if ((int)tiempoModosMov <= 14) {
			Scatter2 ();
			tiempoModosMov = Time.time;
		} else if ((int)tiempoModosMov <= 21) {
			Scatter3 ();
			tiempoModosMov = Time.time;
		} 
			else
		{
			Scatter4 ();
			tiempoModosMov = Time.time;
		}
		if ((int)tiempoModosMov >= 28) {
			tiempoModosMov = 0;
		}
	}

	public virtual void ReiniciarPosicion(){
		this.transform.position = posicionOriginal;
		anim.SetBool ("Afraid", false);
		//spriteRend.color = colorOriginal;
		posicionReiniciada = true;
	}


	public void DentroCasaFC()
	{
		if (cont <= 29 && bloq == 0) {
			valY = transform.position.y + 0.05f;
			cont += 1;
			if (cont >= 29) {
				bloq = 1;
				cont = 0;
			}
		}

		if (cont >= 60) {
			cont = 0;
		}

		if (cont <= 29&& bloq==1) {
			valY= transform.position.y - 0.05f;
			cont += 1;
		}else
		{
			valY =transform.position.y + 0.05f;
			cont += 1;
		}
		transform.position = new Vector3 (transform.position.x, valY, 0f);
	}

	public void DentroCasaFN()
	{
		if (cont <= 29 && bloq == 0) {
			valY2 = transform.position.y - 0.05f;
			cont += 1;
			if (cont >= 29) {
				bloq = 1;
				cont = 0;
			}
		}

		if (cont >= 60) {
			cont = 0;
		}

		if (cont <= 29&& bloq==1) {
			valY2= transform.position.y + 0.05f;
			cont += 1;
		}else
		{
			valY2 =transform.position.y - 0.05f;
			cont += 1;
		}
		transform.position = new Vector3 (transform.position.x, valY2, 0f);
	}

	public virtual void Girar(){
		if (GetComponentHorizontal ()) {

			//print ("Intentando giro horizontal");
			if (direccion.y > 0) {
				//print (direccion.x.ToString ());
				MueveArriba ();

			} else if (direccion.y < 0) {
				//print (direccion.x.ToString ());
				MueveAbajo ();

			} 
		} else if (GetComponentVertical ()) {
			//print ("Intentando giro vertical");
			if (direccion.x > 0) {
				//print ("Derecha");
				MueveDerecha ();

			} else if (direccion.x < 0) {
				//print ("Izquierda");
				MueveIzquierda ();
			} 
		}/* else if (GetComponentHorizontal () && isAfraid) {
			if (direccion.y > 0) {
				//print (direccion.x.ToString ());
				MueveAbajo ();

			} else if (direccion.y < 0) {
				//print (direccion.x.ToString ());
				MueveArriba ();

			} 
		} else if (GetComponentVertical () && isAfraid) {
			if (direccion.x > 0) {
				//print ("Derecha");
				MueveIzquierda ();

			} else if (direccion.x < 0) {
				//print ("Izquierda");
				MueveDerecha ();
			}
		}*/
	}

	protected virtual void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Muro") {
			//print ("Colision con Muro");
			//interseccionCruzAux.SetChildFalse ();
			Girar ();
			if (isAfraid && !enCaminoPuntoInicial) {
				InvertirDireccion ();
			}
		} else if (col.gameObject.tag == "MuroInterseccion") {
			Girar ();
			interseccionCruzAux.SetChildFalse ();
		} else if (col.gameObject.tag == "Abajo") {
			//print ("Abajo");
			MueveAbajo ();
		} else if (col.gameObject.tag == "Arriba") {
			//print ("Arriba");
			MueveArriba ();
		} else if (col.gameObject.tag == "Derecha") {
			//print ("Derecha");
			MueveDerecha ();
		} else if (col.gameObject.tag == "Izquierda") {
			//print ("Izquierda");
			MueveIzquierda ();
		} else if (col.gameObject.tag == "Player" && !isAfraid) {
			//print ("Gotcha");
			Vidas.VidaPerdida ();
		} else if (col.gameObject.tag == "AuxGiroCruz") {
			interseccionCruzAux = col.gameObject.GetComponent<InterseccionCruz> ();
			//interseccionCruzAux.SetChildFalse ();
		} else if (col.gameObject.tag == "MuroInferiorCasa") {
			MueveArriba ();
		} else if (col.gameObject.tag == "AdmFantasmas") {
			canBeAfraid = false;
		}
		//print (col.name);
	}

	protected virtual void OnTriggerExit2D(Collider2D col){
		if (col.tag == "AdmFantasmas") {
			canBeAfraid = true;
		}
	}

	public virtual void RegresarObjetivoOriginal(){
		objetivo = jugadorObjetivo;
	}
}