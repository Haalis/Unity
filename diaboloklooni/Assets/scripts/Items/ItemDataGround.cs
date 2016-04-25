using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemDataGround : MonoBehaviour
{
    ItemDatabase database;
    public Item item;
    public int id = 1;
    public bool istakingshit = false;
    public GameObject player;
    private TooltipDrop tooltip;
    private Inventory inv;
    void Start()
    {
        database = GameObject.Find("Inventory").GetComponent<ItemDatabase>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        tooltip = GameObject.Find("ItemController").GetComponent<TooltipDrop>();
        item = database.FetchItemByID(id);
        //Debug.Log(item);
    }
    void Update()
    {
        if (istakingshit)
        {
            float dist = Vector3.Distance(this.transform.position, player.transform.position);
            if( dist < 2f)
            {
                Debug.Log("Klikattu:D");
                inv.AddItem(id);
                tooltip.Deactivate();
                Destroy(gameObject);
                
            }
        }
    }
    void OnMouseDown()
    {
        istakingshit = true;

    }
    void OnMouseEnter()
    {
       // Debug.Log("Aktivoidaa");
        tooltip.Activate(item);
    }

    void OnMouseExit()
    {
        tooltip.Deactivate();
    }


}
