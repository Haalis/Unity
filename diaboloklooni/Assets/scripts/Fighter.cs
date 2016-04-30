using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {

	public float range;
	public float hitcooldown;
	public int health;
	Animator animator;
	//CharacterController ccontroller;
	public GameObject opponent;
	// Use this for initialization
	float cooldowntimer;

	void Start () {
		animator = GetComponent<Animator>();
	//	ccontroller = GetComponent<CharacterController>();
	}



	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.Space)) {

			Debug.Log (opponent);
			Debug.Log (opponent.GetComponent<mob> ().health);
			//dealdamage ();
			}




	}



	void LateUpdate(){
	


	}

	public void attackanimation1(){

		/*if (this.transform.position - opponent.transform.position < 5f) {
		Vector3 position = new Vector3(opponent.transform.);
			Quaternion newRotation = (Quaternion.LookRotation (this.transform.position - opponent.transform.position));
			newRotation.x = 0f;
			newRotation.z = 0f;

		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, newRotation, Time.deltaTime * 30);
		

			}*/

		transform.LookAt (target: opponent.transform);

			animator.SetBool ("attack", true);
			animator.SetBool ("Runnot", false);
			animator.SetBool ("Walk", false);
	}



	public void dealdamage(){
		if (cooldowntimer <= Time.time) {




			opponent.GetComponent<mob> ().health -= 20;
			Debug.Log (opponent.GetComponent<mob> ().health);

			cooldowntimer = Time.time + hitcooldown;
		} else {
		
			Debug.Log ("cheat");
		}
	
	}





}
