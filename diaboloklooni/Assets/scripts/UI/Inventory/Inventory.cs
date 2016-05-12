using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    ItemDatabase database;
    public GameObject inventoryPanel;
    public GameObject characterPanel;
    GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    public GameObject inventoryDelete;

    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    private bool addItemBoolean;

    void Start()
    {
        database = this.GetComponent<ItemDatabase>();
        slotAmount = 20;
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        // lisää slotit inventoryy
        for(int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            
            slots[i].GetComponent<ItemSlot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
            //Debug.Log(slots.Count);


        }
        //Lisää delete sloti
        items.Add(new Item());
        slots.Add(inventoryDelete);
        slots[slotAmount].GetComponent<ItemSlot>().id = slotAmount;
        slots[slotAmount].transform.SetParent(inventoryPanel.transform);
        //Debug.Log("Tää slotti on "+ slots.Count);
        AddItem(1);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);
        AddItem(100);

    }

    public bool AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);

        if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
            return true;
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().slot = i;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.transform.position = slots[i].transform.position;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.name = itemToAdd.Title;
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount = 1;
                    break;
                }
            }
            return true;
        }

    }



    public void CloseAndOpenInventory(){
        if (inventoryPanel.GetComponent<CanvasGroup>().alpha == 1)
        {
            inventoryPanel.GetComponent<CanvasGroup>().alpha = 0;
            characterPanel.GetComponent<CanvasGroup>().alpha = 0;
        }
        else
        {
            inventoryPanel.GetComponent<CanvasGroup>().alpha = 1;
            characterPanel.GetComponent<CanvasGroup>().alpha = 1;
        }
        }

    public void RemoveItem(int id)
    {
        Item itemToRemove = database.FetchItemByID(id);
        int pos = ItemCheck(itemToRemove);

        //Debug.Log(pos);
        if (pos != -1)
        {
            if (items[pos].Stackable)
            {
                ItemData data = slots[pos].transform.GetComponentInChildren<ItemData>();
                data.amount--;
                if (data.amount == 0)
                {
                    items[pos] = new Item();
                    Transform t = slots[pos].transform.GetChild(0);
                    Destroy(t.gameObject);

                }
                else
                {
                    if (data.amount == 1)
                        data.transform.GetComponentInChildren<Text>().text = "";
                    else
                        data.transform.GetComponentInChildren<Text>().text = data.amount.ToString();
                }
                return;
            }
            else
            {
                items[pos] = new Item();
                Transform t = slots[pos].transform.GetChild(0);
                Destroy(t.gameObject);
                return;
            }
        }
    }
    int ItemCheck(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
                return i;
        }
        return -1;
    }
    bool CheckIfItemIsInInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        
            if (items[i].ID == item.ID)
            
                return true;
            
            return false;
        
    }
}
