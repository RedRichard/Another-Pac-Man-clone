using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterseccionCruz : MonoBehaviour {

	protected Transform child;
	protected GameObject gameObjVer;
	protected GameObject gameObjHor;
	protected Fantasma fantasmaAux;

	public virtual void Start () {
		gameObjHor=this.gameObject.transform.GetChild(0).gameObject;
		gameObjVer = this.gameObject.transform.GetChild (1).gameObject;
		//print (gameObj.tag);
	}

	public virtual void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "Fantasma") {
			print ("si");
			fantasmaAux = col.GetComponent<Fantasma> ();
			if (fantasmaAux.GetComponentHorizontal ()) {
				print ("hor");
				gameObjHor.gameObject.SetActive (true);
			} else {
				print ("ver");
				gameObjVer.gameObject.SetActive (true);
			}
			//gameObj.gameObject.SetActive (true);
		}
	}

	/*void OnTriggerExit2D (Collider2D col){
		gameObjHor.gameObject.SetActive (false);
		gameObjVer.gameObject.SetActive (false);
	}*/

	public virtual void SetChildFalse(){
		gameObjHor.gameObject.SetActive (false);
		gameObjVer.gameObject.SetActive (false);
	}
}
