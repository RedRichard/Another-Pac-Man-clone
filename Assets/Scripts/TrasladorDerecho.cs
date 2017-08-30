using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasladorDerecho : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col){
		//print ("Trigger");
		col.gameObject.GetComponent<Transform> ().position = new Vector2 (0.5f, 17f);
	}
}
