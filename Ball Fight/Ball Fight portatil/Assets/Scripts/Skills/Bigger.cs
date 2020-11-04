using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bigger : MonoBehaviour {
	public float duracion=7.5f;
	public float aumentoTamaño = 1;
	public float aumentoBalas = 0.3f;
	public GameObject bigBullet;
	public GameObject normalBullet;
	public Text texto;
	float tempo;


	public void Start () {
		texto.GetComponent<Text> ().enabled = true;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
		while (transform.localScale.x < aumentoTamaño) {
				transform.localScale+=new Vector3 (0.0005f, 0.0005f, 0.0005f);
		}
		GetComponent<Shoot> ().bullet = bigBullet;
		texto.fontSize = 10;


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

		if (GetComponent<Bigger> ().enabled == true) {
			transform.localScale = new Vector3 (0.6f, 0.6f, 0.6f);
			texto.fontSize = 20;
		}
		GetComponent<Shoot> ().bullet = normalBullet;
		GetComponent<Bigger> ().enabled = false;
	}
}
