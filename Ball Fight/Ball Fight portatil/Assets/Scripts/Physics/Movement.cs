using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float velocity = 2f;
	public float dashForce = 3f;
	public float tiempoRecuperar = 3f;
	public float smoothForce = 4f;

	public bool recuperado = true;
    // Update is called once per frame
    void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * velocity * Time.deltaTime, Space.World);
			if (Input.GetKeyDown (KeyCode.LeftShift) && recuperado==true) {
				GetComponent<Rigidbody> ().AddForce (new Vector3 (dashForce, 0, 0), ForceMode.VelocityChange);
				StartCoroutine (Recuperar (tiempoRecuperar));
			}
        }
		if (GetComponent<Bouncy> ().enabled == false && Input.GetKeyUp (KeyCode.D)) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (smoothForce, 0, 0), ForceMode.VelocityChange);
		}
		if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * velocity * Time.deltaTime, Space.World);
			if (Input.GetKeyDown (KeyCode.LeftShift) && recuperado==true) {
				GetComponent<Rigidbody> ().AddForce (new Vector3 (-dashForce, 0, 0), ForceMode.VelocityChange);
				StartCoroutine (Recuperar (tiempoRecuperar));
			}
        }
		if (GetComponent<Bouncy> ().enabled == false && Input.GetKeyUp (KeyCode.A)) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (-smoothForce, 0, 0), ForceMode.VelocityChange);
		}
    }

	IEnumerator Recuperar(float seconds){
		recuperado = false;
		//Esperará "seconds" segundos, y despues hace lo de abajo. Mientras espera,está ejecutando Update().
		yield return new WaitForSeconds (seconds);
		recuperado = true;
	}
}
