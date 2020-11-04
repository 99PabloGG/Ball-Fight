using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Jumper : MonoBehaviour
{

	public float jumpForce = 50f;
	public int maxSaltos = 1;
	int NSaltos = 0;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.W)) {
			NSaltos += 1;
			if (NSaltos <= maxSaltos) {
				GetComponent<Rigidbody> ().AddForce (new Vector3 (0, jumpForce, 0), ForceMode.VelocityChange);
			}
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Suelo") {
			NSaltos = 0;
		}
	}
}