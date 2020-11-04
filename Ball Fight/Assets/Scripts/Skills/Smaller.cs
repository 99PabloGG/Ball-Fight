using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Smaller : MonoBehaviour {
	public float duracion=7.5f;
	public float disminucion = 0.1f;
	public Text texto;
	float tempo;


	void Start () {
		texto.GetComponent<Text> ().enabled = true;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
		while (transform.localScale.x >= disminucion) {
			transform.localScale-=new Vector3 (0.0005f, 0.0005f, 0.0005f);
		}
		GetComponent<Bigger> ().texto.transform.localScale *= 2;

		StartCoroutine (Timer (duracion));
	}
	void Update () {
		tempo += Time.smoothDeltaTime;
		texto.text = Math.Round ((duracion - tempo),1).ToString();
		if (System.Convert.ToSingle (texto.text) <= 0.0f) {
			texto.text = null;
			texto.enabled = false;
		}

	}
	IEnumerator Timer(float seconds){
		//Esperará "seconds" segundos, y despues hace lo de abajo. Mientras espera,está ejecutando Update().
		yield return new WaitForSeconds (seconds);

		transform.localScale = new Vector3 (0.6f, 0.6f, 0.6f);
		GetComponent<Bigger> ().texto.transform.localScale = new Vector3(0.12f,0.18f,1f);
	}
}
