﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bouncy : MonoBehaviour {
	public float duracion=7.5f;
	public Text texto;
	float tempo;
	public PhysicMaterial material;

	void Start () {
		texto.GetComponent<Text> ().enabled = true;
		GetComponent<SphereCollider> ().material = material;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
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

		GetComponent<SphereCollider> ().material = null;
		GetComponent<Bouncy> ().enabled = false;

	}
}
