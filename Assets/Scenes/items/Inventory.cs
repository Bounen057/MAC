using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] items; // 0-24
    public Item item_cursor; // cursor

    void Start()
    {
        items = new Item[25];
        items[0] = new Item(0, null, 3);
        Debug.Log(items[0]);
        Debug.Log(items[0].name_current);
    }

    // give player items
    public bool give(Item item)
    {
        for(int i = 0;i < 25; i++)
        {
            if(items[i] == null)
            {
                items[i] = item;
                return true;
            }
        }

        return false;
    }
}
