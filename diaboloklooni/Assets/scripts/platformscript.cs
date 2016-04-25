using UnityEngine;
using System.Collections;

public class platformscript : MonoBehaviour {

	Transform player;

	public float cooldowntimer;
	// Use this for initialization
	void Start () {
		player = GetComponentInParent<mob>().player;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnMouseOver(){

		player.GetComponent<Fighter> ().opponent = transform.parent.gameObject;
	}





	void OnMouseDown(){
		if (Vector3.Distance (transform.position, player.position) < player.GetComponent<Fighter> ().range) {
			player.GetComponent<Fighter> ().attackanimation1 ();
			player.GetComponent<Fighter> ().dealdamage ();
		} 
		
	}


	}

