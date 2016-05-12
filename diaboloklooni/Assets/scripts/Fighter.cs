using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fighter : MonoBehaviour {

	public float range;
	public float hitcooldown;
	public int health;
    public int maxHealth;
	public int maxmana;
	public int mana;
    public int minDamage;
    public int maxDamage;
    
    Animator animator;
	//CharacterController ccontroller;
	public GameObject opponent;

	float cooldowntimer;

	void Start () {
        minDamage = 1;
        maxDamage = 5;
        textcontroller.Initialize();
        animator = GetComponent<Animator>();
	//	ccontroller = GetComponent<CharacterController>();

	}



	// Update is called once per frame
	void Update () {
		//textcontroller.CreateFloatingText ("20", transform);
		if (Input.GetKey (KeyCode.Space)) {

			mana --;
			//dealdamage ();
			}

        if (health > maxHealth)
        {
            health = maxHealth;
        } 
		if (mana > maxmana)
		{
			mana = maxmana;
		} 
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
            
        
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



            int damage = (int)Random.Range(minDamage, maxDamage);
			opponent.GetComponent<mob> ().health -= damage;
            textcontroller.CreateFloatingText(damage.ToString(), opponent.transform);
			Debug.Log (opponent.GetComponent<mob> ().health);

			cooldowntimer = Time.time + hitcooldown;
		} else {
		
			Debug.Log ("cheat");
		}
	
	}

	public void damagepop(int damagetaken){





	}



}
