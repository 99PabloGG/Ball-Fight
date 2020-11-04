using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGravity : MonoBehaviour {
	public float gravedad = -9.81f;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (new Vector3 (0, gravedad, 0), ForceMode.Acceleration);	
	}
}
