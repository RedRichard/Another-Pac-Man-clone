using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrianguloInferiorSuperior : InterseccionCruz {

	//private Transform child;
	//private GameObject gameObjHor;
	//private Fantasma fantasmaAux;

	override public void Start () {
		gameObjHor = this.gameObject.transform.GetChild(0).gameObject;
		//gameObjVer = this.gameObject.transform.GetChild (1).gameObject;
		//print (gameObj.tag);
	}

	override public void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "Fantasma") {
			//print ("si");
			fantasmaAux = col.GetComponent<Fantasma> ();
			if (fantasmaAux.GetComponentHorizontal ()) {
				print ("hor");
				gameObjHor.gameObject.SetActive (true);
			} /*else {
				print ("ver");
				gameObjHor.gameObject.SetActive (true);
			}*/
			//gameObj.gameObject.SetActive (true);
		}
	}

	/*void OnTriggerExit2D (Collider2D col){
		gameObjHor.gameObject.SetActive (false);
		gameObjVer.gameObject.SetActive (false);
	}*/

	override public void SetChildFalse(){
		gameObjHor.gameObject.SetActive (false);
		//gameObjVer.gameObject.SetActive (false);
	}
}
