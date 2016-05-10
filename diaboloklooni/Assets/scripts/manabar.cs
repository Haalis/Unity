using UnityEngine;
using System.Collections;

public class manabar : MonoBehaviour {

	float healthh;
	float maxhealthh;
	//GameObject parentti;
	GameObject pelaaja;
	//GameObject kamera;
	Vector2 n;
	//Quaternion rota;
	// Use this for initialization
	void Start () {

		pelaaja = GameObject.FindGameObjectWithTag ("Player");
		//parentti = GameObject.Find ("heltit");
		maxhealthh = pelaaja.GetComponent<Fighter>().maxmana;
		//kamera = GameObject.Find ("Main Camera");
		//rota = parentti.transform.rotation;
	}



	// Update is called once per frame
	void Update () {
		//n = kamera.transform.position - parentti.transform.position; 
		healthh = pelaaja.GetComponent<Fighter>().mana;
		float barlength = healthh / maxhealthh ; 
		transform.localScale = new Vector3 (barlength, 1f, 1f);
		//parentti.transform.rotation = Quaternion.LookRotation(n) * Quaternion.Euler(0, 90, -90);
		//parentti.transform.rotation = rota;


	}
}
