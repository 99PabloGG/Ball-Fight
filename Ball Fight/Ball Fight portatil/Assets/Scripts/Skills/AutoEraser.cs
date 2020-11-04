using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoEraser : MonoBehaviour {
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
