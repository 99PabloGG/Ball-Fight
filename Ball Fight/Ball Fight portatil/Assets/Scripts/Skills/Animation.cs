using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour {
	public int velocidad = 5;

	void FixedUpdate () {
		transform.Rotate (0, 0, velocidad);
	}
}
