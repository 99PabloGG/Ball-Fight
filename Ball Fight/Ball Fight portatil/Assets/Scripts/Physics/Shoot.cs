using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	GameObject bigBullet;

	public bool recuperado = true;
	public float tiempoRecuperar = 0.2f;

	// Update is called once per frame 			 && Camera.main.ScreenToWorldPoint (Input.mousePosition).y<=transform.position.y-1 && Camera.main.ScreenToWorldPoint (Input.mousePosition).y>=transform.position.y+1 
	void Update () {
		
		if (GetComponent<Infinity> ().enabled == false && recuperado == true && Input.GetMouseButtonDown (0)) {
			if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x <= transform.position.x - 0.9f || Camera.main.ScreenToWorldPoint (Input.mousePosition).x >= transform.position.x + 0.9f || Camera.main.ScreenToWorldPoint (Input.mousePosition).y <= transform.position.y - 0.9f || Camera.main.ScreenToWorldPoint (Input.mousePosition).y >= transform.position.y + 0.9f)
				{
					Instantiate (bullet, transform.position + (((Camera.main.ScreenToWorldPoint (Input.mousePosition) - new Vector3 (0f, 0f, Camera.main.transform.position.z)) - transform.position) / ((Camera.main.ScreenToWorldPoint (Input.mousePosition) - new Vector3 (0f, 0f, Camera.main.transform.position.z)) - transform.position).magnitude)/1.1f, gameObject.transform.rotation);
					StartCoroutine (Recuperar (tiempoRecuperar));
				}
		}else if (GetComponent<Infinity> ().enabled == true && Input.GetMouseButton (0))
			Instantiate (bullet, transform.position + (((Camera.main.ScreenToWorldPoint (Input.mousePosition) - new Vector3 (0f, 0f, Camera.main.transform.position.z)) - transform.position) / ((Camera.main.ScreenToWorldPoint (Input.mousePosition) - new Vector3 (0f, 0f, Camera.main.transform.position.z)) - transform.position).magnitude)/1.1f, gameObject.transform.rotation);
	}

	IEnumerator Recuperar(float seconds){
		recuperado = false;
		//Esperará "seconds" segundos, y despues hace lo de abajo. Mientras espera,está ejecutando Update().
		yield return new WaitForSeconds (seconds);
		recuperado = true;
	}
}
