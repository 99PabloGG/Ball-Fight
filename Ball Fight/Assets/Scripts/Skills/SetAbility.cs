using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAbility : MonoBehaviour {

	public bool isFreezed = false;

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Fly") {

			resetState ();
			GetComponent<Fly> ().enabled = true;
		}
		if (col.gameObject.name == "Bouncy") {
			resetState ();
			GetComponent<Bouncy> ().enabled = true;
		}
		if (col.gameObject.name == "Bigger") {
			resetState ();
			GetComponent<Bigger> ().enabled = true;
		}
		if (col.gameObject.name == "Smaller") {
			resetState ();
			GetComponent<Smaller> ().enabled = true;
		}
		if (col.gameObject.name == "Freeze") {
			resetState ();
			GetComponent<Freeze> ().enabled = true;
		}

	}
	void resetState (){
		if(isFreezed == false) //si hay freeze, no resetees.
		{
			//Estados propios
			GetComponent<Rigidbody> ().useGravity = true;//cambios Fly
			GetComponent<Jumper> ().enabled= true;
			GetComponent<Movement> ().enabled= true;

			GetComponent<SphereCollider> ().material = null;//cambios Bouncy

			transform.localScale = new Vector3 (0.6f, 0.6f, 0.6f);//cambios Bigger/Smaller
			GetComponent<Bigger> ().texto.fontSize = 20;
			GetComponent<Bigger> ().texto.transform.localScale = new Vector3(0.12f,0.18f,1f);

			for (int i = 0; i < GameObject.FindGameObjectsWithTag ("Player").Length; i++) {		//cambios Freeze
				GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Shoot> ().enabled = true;
				GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Jumper> ().enabled= true;
				GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<Movement> ().enabled= true;	
			}

			//Estados skills
			GetComponent<Fly> ().enabled = false;
			GetComponent<Bouncy> ().enabled = false;
			GetComponent<Bigger> ().enabled = false;
			GetComponent<Smaller> ().enabled = false;
			GetComponent<Freeze> ().enabled = false;
		}

	}
}
