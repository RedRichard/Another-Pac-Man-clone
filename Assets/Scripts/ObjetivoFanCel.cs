using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoFanCel : MonoBehaviour {

	public GameObject player;
	private GameObject fantasma;

	float direccion=4;
	float xPlayer;
	float yPlayer;
	float xFantCel;
	float yFantCel;
	float xNueva;
	float yNueva;
	float disX;
	float disY;


	// Use this for initialization
	void Start () {
		fantasma = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			//Debug.Log ("Fecha arriba");
			direccion=1;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			//Debug.Log ("Flecha abajo");
			direccion=2;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			//Debug.Log ("Flecha izquierda");
			direccion=3;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			//Debug.Log ("Flecha derecha");
			direccion =4;
		}

		xPlayer=player.transform.position.x;
		yPlayer=player.transform.position.y;

		if (direccion==1)
		{
			yPlayer+=1;
		}

		if (direccion==2)
		{
			yPlayer-=1;
		}
		if (direccion==3)
		{
			xPlayer-=1;
		}
		if (direccion==4)
		{
			xPlayer+=1;
		}

		xFantCel=fantasma.transform.position.x;
		yFantCel=fantasma.transform.position.y;
		disX = xFantCel - xPlayer;
		disY = yFantCel - yPlayer;
		xNueva = (-1.5f * disX) + xFantCel;
		yNueva = (-1.5f * disY) + yFantCel;
		transform.position = new Vector3 (xNueva, yNueva, 0f);
	}
}
