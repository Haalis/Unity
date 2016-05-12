using UnityEngine;
using System.Collections;

public class mob : MonoBehaviour {

	float cooldowntimer;
	public int health;
	public float movespeed;
	float speed;
	public float hitcooldown;
	public float range;
	public CharacterController controller;
	GameObject playerobject;
	public Transform player;
	bool aggro = false;

	Animator animator;
	// Use this for initialization
	void Start () {
		speed = movespeed;
		animator = GetComponent<Animator>();
		playerobject = GameObject.FindGameObjectWithTag ("Player");
		player = playerobject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool ("Runnot", false);
		aggroch ();
		deathch ();
		lookatplayer();
		chase ();
		
	}

	void deathch(){
	
		if (health <= 0) {
		
			Destroy (gameObject, 1);
		
		}
	
	
	}

	bool inRange(){

		if(Vector3.Distance (transform.position, player.position) < range){

			return true;
		} else {
			return false;
		}

	}

	void lookatplayer (){
		if(aggro == true && Vector3.Distance (transform.position, player.position) > range  && cooldowntimer < Time.time){
		
		Quaternion newRotation = Quaternion.LookRotation (player.position - transform.position);

		newRotation.x = 0f;
		newRotation.z = 0f;

		transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 30);


	}
}

	void chase(){
		if (aggro == true && Vector3.Distance (transform.position, player.position) > range  && cooldowntimer < Time.time) {
			controller.SimpleMove (transform.forward * speed);
			speed = movespeed;

			animator.SetBool ("Runnot", true);
			animator.SetBool ("attack", false);

		} else if (aggro == true) {
		
			mobattack ();
			speed = 0;
		}

	}

	void mobattack(){
	
		if (cooldowntimer <= Time.time) {
			aggro = false;
            int damage = (int)Random.Range(5.0f, 10.0f);
            player.GetComponent<Fighter> ().health -= 20;
            textcontroller.CreateFloatingText(damage.ToString(), player.transform);
            //Otin tänki pois:D
            //Debug.Log (player.GetComponent<Fighter> ().health);
            animator.SetBool ("Runnot", false);
			animator.SetBool ("attack", true);
			cooldowntimer = Time.time + hitcooldown;

		} else {

            //Otin tän pois päält ku floodas koko paska :D
			//Debug.Log ("cheatan");
		}
	
	}


	void aggroch(){
		if(Vector3.Distance (transform.position, player.position) < 15){
			aggro = true;
		
		}
		if (Vector3.Distance (transform.position, player.position) > 60) {
		
			aggro = false;
		}
	}



	/*void OnMouseOver(){

		Debug.Log ("hovered");
		player.GetComponent<Fighter>().opponent = gameObject;
	}





	void OnMouseDown(){


		player.GetComponent<Fighter> ().attackanimation ();
		Debug.Log ("clicked");

	}

--**/


}