using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int id; //  ID of item
    public string name_current; //  nickname of item
    public int amount; // yes

    public Sprite icon;


    private ItemMeta itemMeta;


    public Item(int id, string name_current, int amount)
    {
        this.id = id;

        // get meta data
        itemMeta = Resources.Load<ItemMeta>("ItemMeta/" + new IdToName().GetName(id) + "");


        if (name_current == null)
        {
            this.name_current = itemMeta.itemName;
        }
        this.amount = amount;
        this.icon = itemMeta.icon;
    }
}
