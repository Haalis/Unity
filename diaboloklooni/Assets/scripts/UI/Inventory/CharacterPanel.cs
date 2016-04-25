using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{

    Inventory inventory;
    // playerStats stats;

    void Start()
    {
        //stats = GameObject.Find("Player").GetComponent<playerStats>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void EquipItem(Item newEquip)
    {
        foreach (Transform child in transform)
        {
            try
            {
                if (child.GetComponent<EquipmentSlot>().equipmentType == newEquip.ItemType)
                {
                    
                    EquipmentSlot equip = child.GetComponent<EquipmentSlot>();
                    Debug.Log("CP equip1");
                    //Letz check if item is not equipped
                    if (equip.equippedItem == null)
                    {
                        

                        inventory.RemoveItem(newEquip.ID);
                        Debug.Log("CP equip2");
                        equip.equippedItem = newEquip;
                        
                        Debug.Log("SLUg2" + equip.equippedItem.Slug);

                    }
                    else
                    {
                        Debug.Log("CP equip3");
                        //Inventorystä itemi vittuu
                        inventory.RemoveItem(newEquip.ID);
                        //Pistetää tavara equip slottii
                        Item holder = equip.equippedItem;
                        //Pistetää slotista vanha itemi takas invaa
                        if (inventory.AddItem(holder.ID) == true)
                        {
                            equip.equippedItem = newEquip;
                        }
                        else
                        {
                            inventory.AddItem(newEquip.ID);
                        }
                    }

                    child.GetChild(0).GetComponent<Image>().sprite = newEquip.Sprite;
                    child.GetChild(0).GetComponent<CanvasGroup>().alpha = 1;

 
                    /*
                    stats.additionalAttackPower = newEquip.Power;
                    stats.additionalAttackSpeed = newEquip.Speed;
                    int totalAttack = stats.additionalAttackPower + stats.baseAttackPower;
                    int totalSpeed = stats.additionalAttackSpeed + stats.baseAttackSpeed;
                    transform.GetChild(0).GetComponent<Text>().text = "Power - " + totalAttack + "\nSpeed - " + totalSpeed;
                    */
                }
            }
            catch { }
        }
    }
}