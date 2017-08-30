using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivosPuntos : MonoBehaviour {

	public GameObject puntosPacman;
	private Transform auxPunto;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//print (this.transform.childCount);

		if (this.transform.childCount == 0) {
			(new LevelManager()).SiguienteNivel();
			foreach (Transform punto in puntosPacman.transform.GetComponentsInChildren<Transform> ()) {
				if (punto.parent == puntosPacman.transform) {
					auxPunto = Instantiate (punto);
					auxPunto.transform.parent = this.gameObject.transform;
				}
			}
			/*auxPunto = Instantiate (puntosPacman.transform);
			auxPunto.transform.position = Vector2.zero;
			auxPunto.transform.parent = this.gameObject.transform.parent;*/
			//print ("Si llega aqui");
			//Destroy (this.transform.gameObject);
		}
	}
}
