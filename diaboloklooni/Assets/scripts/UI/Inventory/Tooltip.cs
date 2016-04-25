using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
    private Item item;
    private string data;
    private GameObject tooltip;
    void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }
    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }
    public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }
    public void Deactivate()
    {
        tooltip.SetActive(false);
    }
    public void ConstructDataString()
    {
        if (item.ItemType == "consumable")
        {
            data = "<color=#ffffff><b>" + item.Title + "</b></color>\n\n" +
    item.Description + "\n\n" +
     "Power: " +item.Damage + " HP " + "\n" +
    "Duration: " + item.Duration + " s\n";
            tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
        }
        else {
            data = "<color=#00cc00><b>" + item.Title + "</b></color>\n\n" +
                item.Description + "\n\n" +
                "Damage: " + item.Damage + "\n" +
                "Attack Speed: " + item.AttackSpeed + " %\n";
            tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
        }
    }
}
