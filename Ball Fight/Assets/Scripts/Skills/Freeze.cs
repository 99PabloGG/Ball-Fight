using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Freeze : MonoBehaviour {
	public float duracion=7.5f;
	public Text texto;
	float tempo;

	void Start () {
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
		for (int i = 0; i < GameObject.FindGameObjectsWithTag ("Player").Length; i++) {
			GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Rigidbody> ().useGravity = true;//cambios Fly
			GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Jumper> ().enabled= true;
			GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Movement> ().enabled= true;
			GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Fly> ().enabled = false;

			GameObject.FindGameObjectsWithTag ("Player") [i].GetComponent<SetAbility> ().isFreezed = true; //marcalo como freezed
			GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Fly> ().texto.enabled= false;	// quitale el temporizador

			GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Shoot> ().enabled = false;
			GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Jumper> ().enabled= false;
			GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Movement> ().enabled= false;

			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
			}
		GetComponent<SetAbility> ().isFreezed = false;
		GetComponent<Shoot> ().enabled = true;
		GetComponent<Jumper> ().enabled= true;
		GetComponent<Movement> ().enabled= true;
		texto.GetComponent<Text> ().enabled = true;

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

		for (int i = 0; i < GameObject.FindGameObjectsWithTag ("Player").Length; i++) {
			GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Shoot> ().enabled = true;
			GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Jumper> ().enabled= true;
			GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Movement> ().enabled= true;

			GameObject.FindGameObjectsWithTag ("Player") [i].GetComponent<SetAbility> ().isFreezed = false;

		}

	}
}
