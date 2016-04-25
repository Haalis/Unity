using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        /* 
         Item item = new Item(0, "Ball", 5);
         database.Add(item);
         Debug.Log(database[0].Title);
         */
        //Debug.Log("Mennäää täs");
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        //Debug.Log("Mennäää täs");
        ConstructItemDatabase();

       
    }

    //example FetchItemByID(0).Description
    public Item FetchItemByID(int id)
    {
       // Debug.Log(database.Count);
        for (int i = 0; i < database.Count; i++)
        {
            
            if (database[i].ID == id)
            {
                return database[i];
            }
        }
        return null;
    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item(
                (int)itemData[i]["id"],
                itemData[i]["title"].ToString(),
                itemData[i]["itemtype"].ToString(), 
                (int)itemData[i]["value"],
                (int)itemData[i]["stats"]["attackspeed"],
                (int)itemData[i]["stats"]["damage"],
                (int)itemData[i]["stats"]["defence"],
                (int)itemData[i]["stats"]["duration"],
                (int)itemData[i]["stats"]["vitality"], 
                itemData[i]["description"].ToString(),
                (bool)itemData[i]["stackable"],
                (int)itemData[i]["rarity"],
                itemData[i]["slug"].ToString()));
        }
    }
}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string ItemType { get; set; }
    public int Value { get; set; }
    public int AttackSpeed { get; set; }
    public int Damage { get; set; }
    public int Defence { get; set; }
    public int Duration { get; set; }
    public int Vitality { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string title, string itemtype, int value, int attackspeed, int damage, int defence, int duration, int vitality, string description, bool stackable, int rarity, string slug )
    {
        this.ID = id;
        this.Title = title;
        this.ItemType = itemtype;
        this.Value = value;
        this.AttackSpeed = attackspeed;
        this.Damage = damage;
        this.Defence = defence;
        this.Duration = duration;
        this.Vitality = vitality;
        this.Description = description;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);

    }
    public Item()
    {
     this.ID = -1;
    }
}