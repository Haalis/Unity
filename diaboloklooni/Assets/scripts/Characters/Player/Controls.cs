using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
    public GameObject Inventory;
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            Inventory.GetComponent<Inventory>().CloseAndOpenInventory();
        }
        if (Input.GetKeyDown("1"))
        {
            
            Debug.Log("1");
        }
        if (Input.GetKeyDown("2"))
        {
            Debug.Log("2");
        }
        if (Input.GetKeyDown("3"))
        {
            //HEALING SPELL ID 0
            this.GetComponent<SpellManager>().CastSpell(0);
            Debug.Log("3");
        }
        if (Input.GetKeyDown("4"))
        {
            Debug.Log("4");
        }

    }
}
