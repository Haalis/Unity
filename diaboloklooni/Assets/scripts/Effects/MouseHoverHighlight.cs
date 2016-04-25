using UnityEngine;
using System.Collections;

public class MouseHoverHighlight : MonoBehaviour {

    private Color startcolor;
    void OnMouseEnter()
    {
        startcolor = GetComponent<Renderer>().material.color;
        this.GetComponent<Renderer>().material.color = Color.yellow;
    }
    void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = startcolor;
    }
}
