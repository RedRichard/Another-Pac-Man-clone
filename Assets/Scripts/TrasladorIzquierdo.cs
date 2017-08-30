using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasladorIzquierdo : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col){
		col.gameObject.GetComponent<Transform> ().position = new Vector2 (28.5f, 17f);
	}
}
