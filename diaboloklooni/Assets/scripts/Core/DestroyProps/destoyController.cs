using UnityEngine;
using System.Collections;

public class destoyController : MonoBehaviour {
    public GameObject Fragments;
	// Update is called once per frame

	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(Fragments, this.transform.position, this.transform.rotation);

            Destroy(gameObject);
            Debug.Log("Space painettu");
        }
    }
}
