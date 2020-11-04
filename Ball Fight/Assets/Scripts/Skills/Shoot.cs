using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject bullet;

	// Update is called once per frame 			 && Camera.main.ScreenToWorldPoint (Input.mousePosition).y<=transform.position.y-1 && Camera.main.ScreenToWorldPoint (Input.mousePosition).y>=transform.position.y+1 
	void Update () {
		if (Input.GetMouseButtonDown(0)) 
		{
			if(Camera.main.ScreenToWorldPoint (Input.mousePosition).x<=transform.position.x-0.5f || Camera.main.ScreenToWorldPoint (Input.mousePosition).x>=transform.position.x+0.5f || Camera.main.ScreenToWorldPoint (Input.mousePosition).y<=transform.position.y-0.5f || Camera.main.ScreenToWorldPoint (Input.mousePosition).y>=transform.position.y+0.5f)
			{
				Instantiate (bullet, transform.position+(((Camera.main.ScreenToWorldPoint (Input.mousePosition)-new Vector3(0f,0f,Camera.main.transform.position.z)) - transform.position) / ((Camera.main.ScreenToWorldPoint (Input.mousePosition)-new Vector3(0f,0f,Camera.main.transform.position.z)) - transform.position).magnitude)/2, gameObject.transform.rotation);
			}
		}
	}
}
