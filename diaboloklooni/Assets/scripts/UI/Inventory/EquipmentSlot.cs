using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler{

    public string equipmentType;
    public Item equippedItem = null;
    Inventory inv;
    Tooltip tooltip;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        tooltip = inv.GetComponent<Tooltip>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerId == -2)
        {
            if (inv.AddItem(equippedItem.ID) != false)
            {
                
                transform.GetChild(0).GetComponent<CanvasGroup>().alpha = 0;

                /*
                stats.additionalAttackPower -= equippedItem.Power;
                stats.additionalAttackSpeed -= equippedItem.Speed;
                int totalAttack = stats.additionalAttackPower + stats.baseAttackPower;
                int totalSpeed = stats.additionalAttackSpeed + stats.baseAttackSpeed;
                transform.parent.transform.GetChild(0).GetComponent<Text>().text = "Power - " + totalAttack + "\nSpeed - " + totalSpeed;
                */
                //Deactive the tooltip since the item is now gone
                tooltip.Deactivate();
                //Clear the equipped item slot
                equippedItem = null;
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (equippedItem.ID != -1)
            tooltip.Activate(equippedItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }
}
