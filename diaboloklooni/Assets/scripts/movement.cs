using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	Animator animator;
	float speed;
	public float defspeed;
	public float movespeedd;
	public CharacterController controller;
	private Vector3 position;
    UnitPlayer UnitPlayer;


    public static Vector3 cursorPosition;
    public Vector3 target;

    Vector3[] path;
    int targetIndex;


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
    void locatePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag != "Player" && hit.collider.tag != "Enemy")
            {
                position.y = 0.1f;
                position = hit.point;


            }
        }
    }

    void locateCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            cursorPosition.y = 0.1f;
            cursorPosition = hit.point;
        }
    }
    /*
	void locatePosition(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if(Physics.Raycast(ray, out hit, 1000)){
			
			position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			
			
			
		}

	}

        */

    /*public void moveToRange(){
	
		while (Vector3.Distance (transform.position, position) + GetComponentInParent<Fighter> ().range > GetComponentInParent<Fighter> ().range) {
		
			moveToPosition ();
			GetComponentInParent<Fighter> ().dealdamage ();
		
		}



	
	}*/




    void moveToPosition(){


		if (Vector3.Distance (transform.position, position) > 1.1) {
            PathRequestManager.RequestPath(transform.position, target, OnPathFound);
            target = position;
            if (path[0] != null)
            {
                Quaternion newRotation = Quaternion.LookRotation(path[0] - transform.position);

                newRotation.x = 0f;
                newRotation.z = 0f;

                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 50);
                
            }
            
            //controller.SimpleMove (transform.forward * speed);




        }

		if (Vector3.Distance (transform.position, position) < 3.5) {


			speed = defspeed / 3;
       
        } else {
			speed = defspeed;
   
        }
	
		if (Vector3.Distance (transform.position, position) > 3.5) {
		
			animator.SetBool ("Runnot", true);
			animator.SetBool ("Walk", false);
		
		} else if (Vector3.Distance (transform.position, position) > 2) {

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


    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {

        if (pathSuccessful)
        {

            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        if (path[0] != null)
        {
            Vector3 currentWaypoint = path[0];

            while (true)
            {
                if (transform.position == currentWaypoint)
                {
                    targetIndex++;
                    if (targetIndex >= path.Length)
                    {
                        Debug.Log("Perillä");
                        yield break;
                    }
                    currentWaypoint = path[targetIndex];
                    
                }

                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
                yield return null;

            }
        }
    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }









}