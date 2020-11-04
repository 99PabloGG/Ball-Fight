using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAction : MonoBehaviour {

	public int velocidad=20;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce ((((Camera.main.ScreenToWorldPoint (Input.mousePosition)-new Vector3(0f,0f,Camera.main.transform.position.z)) - transform.position) / ((Camera.main.ScreenToWorldPoint (Input.mousePosition)-new Vector3(0f,0f,Camera.main.transform.position.z)) - transform.position).magnitude) * velocidad, ForceMode.Impulse);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Suelo") {
			Destroy(gameObject);
		}
	}
}