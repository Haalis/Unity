using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	Animator animator;
	float speed;
	public float defspeed;
	public float movespeedd;
	public CharacterController controller;
	private Vector3 position;



	// Use this for initialization
	void Start () {
		position = transform.position;
		animator = GetComponent<Animator>();
		defspeed = movespeedd;
		animator.SetBool ("attack", false);
		animator.SetBool ("Runnot", false);
		animator.SetBool ("Walk", false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0) && animator.GetBool ("attack") == false){
			locatePosition();
			
		}
	
		if (animator.GetBool ("attack") == false) {
			moveToPosition ();
		} else {
			animator.SetBool ("Runnot", false);
			animator.SetBool ("Walk", false);
			stopmove ();
		}
	}
	
	void locatePosition(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if(Physics.Raycast(ray, out hit, 1000)){
			
			position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			
			
			
		}

	}



	/*public void moveToRange(){
	
		while (Vector3.Distance (transform.position, position) + GetComponentInParent<Fighter> ().range > GetComponentInParent<Fighter> ().range) {
		
			moveToPosition ();
			GetComponentInParent<Fighter> ().dealdamage ();
		
		}



	
	}*/




	void moveToPosition(){


		if (Vector3.Distance (transform.position, position) > 1.1) {
			
			Quaternion newRotation = Quaternion.LookRotation (position - transform.position);
		
			newRotation.x = 0f;
			newRotation.z = 0f;
		
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 50);
		
			controller.SimpleMove (transform.forward * speed);
	
		
		}

		if (Vector3.Distance (transform.position, position) < 3.5) {


			speed = defspeed / 3;
		} else {
			speed = defspeed;
		}
	
		if (Vector3.Distance (transform.position, position) > 3.5) {
		
			animator.SetBool ("Runnot", true);
			animator.SetBool ("Walk", false);
		
		} else if (Vector3.Distance (transform.position, position) > 1.5) {

			animator.SetBool ("Walk", true);
			animator.SetBool ("Runnot", false);

		} else {
			animator.SetBool ("Runnot", false);
			animator.SetBool ("Walk", false);


		}

	}




		public void stopmove(){

	position = transform.position;



}














}