using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigueme : MonoBehaviour {
	public GameObject objeto;
	// Update is called once per frame
	void Update () {
		
		transform.position = objeto.transform.position + new Vector3(0f,0.5f,0f);
	}
}
