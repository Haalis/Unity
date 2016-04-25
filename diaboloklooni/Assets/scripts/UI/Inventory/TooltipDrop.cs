using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TooltipDrop : MonoBehaviour {
    private Item item;
    private string data;
    private GameObject tooltip;
    void Start()
    {
        tooltip = GameObject.Find("TooltipDrop");
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
        //Debug.Log("Aktivoitu :D");
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
        data = "<color=#00cc00><b>" + item.Title + "</b></color>\n";
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
