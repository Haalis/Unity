using UnityEngine;
using System.Collections;

public class healthbarupdatermob : MonoBehaviour {
	float healthh;
	float maxhealthh;
	Transform parentti;
	//GameObject kamera;
	Vector2 n;
	Quaternion rota;
	// Use this for initialization
	void Start () {
		maxhealthh = GetComponentInParent<mob>().health;

		parentti = this.transform.parent;

		//kamera = GameObject.Find ("Main Camera");
		rota = parentti.transform.rotation;
	}



	// Update is called once per frame
	void Update () {
		//n = kamera.transform.position - parentti.transform.position; 
		healthh = GetComponentInParent<mob>().health;
		float barlength = healthh / maxhealthh ; 
		transform.localScale = new Vector3 (barlength, 1f, 1f);
		//parentti.transform.rotation = Quaternion.LookRotation(n) * Quaternion.Euler(0, 90, -90);
		parentti.transform.rotation = rota;


	}
}
