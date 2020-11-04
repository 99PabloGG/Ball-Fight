using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Fly : MonoBehaviour {
	public float duracion=7.5f;
	public float velocidad = 3f;
	public Text texto;
	float tempo;

	void Start () {
		GetComponent<Rigidbody> ().useGravity = false;
		GetComponent<Jumper> ().enabled= false;
		GetComponent<Movement> ().enabled= false;
		texto.GetComponent<Text> ().enabled = true;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
		StartCoroutine (Timer (duracion));
	}
	void Update () {
		
		if (Input.GetKey(KeyCode.W))
		{
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, velocidad, 0), ForceMode.Force);
		}
		if (Input.GetKey(KeyCode.S))
		{
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, -velocidad, 0), ForceMode.Force);
		}
		if (Input.GetKey(KeyCode.A))
		{
			GetComponent<Rigidbody> ().AddForce (new Vector3 (-velocidad, 0, 0), ForceMode.Force);
		}
		if (Input.GetKey(KeyCode.D))
		{
			GetComponent<Rigidbody> ().AddForce (new Vector3 (velocidad, 0, 0), ForceMode.Force);
		}
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

		GetComponent<Rigidbody> ().useGravity = true;
		GetComponent<Jumper> ().enabled= true;
		GetComponent<Movement> ().enabled= true;
		GetComponent<Fly> ().enabled = false;

	}
}
