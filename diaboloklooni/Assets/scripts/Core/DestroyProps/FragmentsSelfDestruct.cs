using UnityEngine;
using System.Collections;

public class FragmentsSelfDestruct : MonoBehaviour {
    Vector3 newPos;
    // Use this for initialization
    void Start () {
        StartCoroutine(WaitThenExplode(1f));
        newPos = this.transform.position;
    }

    IEnumerator WaitThenExplode(float time)
    {
        Debug.Log("Aikaa jäljellä :D "+ time);
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Debug.Log("Palaset poies");

    }
}
