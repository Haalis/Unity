using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public int amount;
    public int slot;

    private Transform originalParent;
    private Inventory inv;
    private Tooltip tooltip;
    private Vector2 offset;
    private Transform parentReturnTo;
    private Vector2 positionReturnTo;
    CharacterPanel characterPanel;

    void Start()
    {
        characterPanel = GameObject.Find("Character Panel").GetComponent<CharacterPanel>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        tooltip = inv.GetComponent<Tooltip>();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (item != null)
        {
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        }
        if (eventData.pointerId == -2)
        {
            Debug.Log("VISKATTU");
            if (item.ItemType == "melee" || item.ItemType == "OffHand")
            {
                //int uniqueId = GameObject.Find("Slot Panel").transform.GetChild(slot).transform.GetChild(0).GetInstanceID();
                Debug.Log("VASTAANOTETAAN:DD");
                characterPanel.EquipItem(item);
                tooltip.Deactivate();
            }
            if (item.ItemType == "consumable")
            {
                //TÄNNE SE MITÄ TAPAHTUU KU NAPPAA POTIONEIT:D
                switch (item.ID)
                {
                    case 100:
                        Debug.Log("Health Potion otettu'd");
                        break;
                }
                inv.RemoveItem(item.ID);
                if (this.amount == 0)
                {
                    tooltip.Deactivate();
                }
                  
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            parentReturnTo = this.transform.parent;
            positionReturnTo = this.transform.position;
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - offset;
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        } 
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position - offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

            this.transform.SetParent(inv.slots[slot].transform);
            this.transform.position = inv.slots[slot].transform.position;
            this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (this.transform.parent.name == inv.GetComponent<Inventory>().inventoryDelete.name)
        {
            inv.RemoveItem(this.item.ID);
            if (amount > 0)
            {
                this.transform.SetParent(parentReturnTo);
                this.transform.position = positionReturnTo;
            }
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }
}
