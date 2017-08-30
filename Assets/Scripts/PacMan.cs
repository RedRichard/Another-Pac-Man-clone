using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour {

	public int speed;
	private KeyCode direccion;
	private bool horizontal;
	private bool vertical;
	private Vector2 posicionOriginal;
	public static PacMan thisPlayer;

	// Use this for initialization
	void Start () {
		thisPlayer = this;
		horizontal = true;
		vertical = false;
		direccion = KeyCode.None;
		posicionOriginal = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * speed * Time.deltaTime);
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			direccion = KeyCode.UpArrow;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) && vertical) {
			transform.eulerAngles=new Vector3 (0,0,90f);
			transform.position = new Vector3 (((int)transform.position.x)+0.5f, transform.position.y, 0f);
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			direccion = KeyCode.DownArrow;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && vertical) {
			transform.eulerAngles=new Vector3 (0,0,-90f);
			transform.position = new Vector3 (((int)transform.position.x)+0.5f, transform.position.y, 0f);
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			direccion = KeyCode.LeftArrow;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && horizontal) {
			transform.eulerAngles = new Vector3 (0, 180f, 0);
			transform.position = new Vector3 (transform.position.x, ((int)transform.position.y)+0.5f, 0f);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			direccion = KeyCode.RightArrow;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && horizontal) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.position = new Vector3 (transform.position.x, ((int)transform.position.y)+0.5f, 0f);
		}
	}

	void Gira(){
		if (direccion == (KeyCode.UpArrow)) {
			//Debug.Log ("Fecha arriba");
			transform.eulerAngles=new Vector3 (0,0,90f);
			transform.position = new Vector3 (((int)transform.position.x)+0.5f, transform.position.y, 0f);
			vertical = true;
			horizontal = false;
		}
		if (direccion == (KeyCode.DownArrow)) {
			//Debug.Log ("Flecha abajo");
			transform.eulerAngles=new Vector3 (0,0,-90f);
			transform.position = new Vector3 (((int)transform.position.x)+0.5f, transform.position.y, 0f);
			vertical = true;
			horizontal = false;
		}
		if (direccion == (KeyCode.LeftArrow)) {
			//Debug.Log ("Flecha izquierda");
			transform.eulerAngles = new Vector3 (0, 180f, 0);
			transform.position = new Vector3 (transform.position.x, ((int)transform.position.y)+0.5f, 0f);
			vertical = false;
			horizontal = true;
		}
		if (direccion == (KeyCode.RightArrow)) {
			//Debug.Log ("Flecha derecha");
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.position = new Vector3 (transform.position.x, ((int)transform.position.y)+0.5f, 0f);
			vertical = false;
			horizontal = true;
		}
		direccion = KeyCode.None;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Puntos") {
			//print ("Se deben agregar puntos");
			Score.AgregarPuntos (10);
			FantasmaCeleste.ContarPuntos(10);
			FantasmaNaranja.ContarPuntos (10);
			Destroy (col.gameObject.transform.parent.gameObject);
		}
		if (col.gameObject.tag == "Afraid") {
			AdministradorFantasmas.CambiarAModoAfraid ();
			Score.AgregarPuntos (50);
			Destroy (col.gameObject.transform.parent.gameObject);
		}
		if (col.gameObject.tag == "Fantasma") {
			Fantasma fan = col.GetComponent<Fantasma> ();
			if (fan.GetIsAfraid() == false) {
				ReiniciarPosicion ();
			} else {
				fan.RegresarPuntoInicio ();
				AdministradorFantasmas.AumentarFantasmasMuertos ();
				Score.AgregarPuntosFantasmaMuerto ();
			}
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "PacMan-Giro" && (int)this.transform.position.magnitude == (int)col.transform.position.magnitude && direccion!=KeyCode.None) {
			//speed = 6;
			//print ("Vale");
			Gira ();
		}
	}

	public void ReiniciarPosicion(){
		this.transform.position = posicionOriginal;
		direccion = KeyCode.RightArrow;
		Gira ();
	}
}
