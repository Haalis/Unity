using UnityEngine;
using System.Collections;

public class OnClickMove : MonoBehaviour
{

    public CharacterController controller;
    private Vector3 position;

    public AnimationClip run;
    public AnimationClip idle;


    //public static bool die;
    private bool managerSelected = false;

    public static Vector3 cursorPosition;

    public static bool busy;

    // For initialization
    void Start()
    {
        position = transform.position;
        busy = false;
    }

    void OnMouseDown()
    {
        if (managerSelected)
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 255);
            managerSelected = false;

        }
        else
        {
            managerSelected = true;
            this.gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 255);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (managerSelected)
            {
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 255);
                managerSelected = false;

            }
            else
            {
                managerSelected = true;
                this.gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 255);
            }
        }

        if (!busy)
        {
            speed = 2;
            locateCursor();
            if (managerSelected)
            {
                if (Input.GetMouseButton(0))
                {
                    //Paikantaa hahmon sijainnin
                    LocatePosition();

                }

                //Liikuttaa hahmon kohteeseen
                MoveToPosition();
            }
            else
            {

            }
        }
        else
        {
            //Debug.Log("Is busy");
            speed = 0;
        }
    }

    void LocatePosition()
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



    public Vector3 target;
    float speed = 2;
    Vector3[] path;
    int targetIndex;

    public void MoveToPosition()
    {
        target = position;
        PathRequestManager.RequestPath(transform.position, target, OnPathFound);
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
        Vector3 currentWaypoint = path[0];

        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;

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