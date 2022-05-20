using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] items; // 0-24
    public Item itemCursor; // The Item you have just now
    public GameObject image_cursor;
    public GameObject InventoryWindow; // Window

    void Start()
    {
        items = new Item[25];
        items[0] = new Item(0, null, 3);
    }

    void Update()
    {
        // Cursor Item
        image_cursor.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        if (!new IsNull().Judge(itemCursor))
        {
            image_cursor.GetComponent<Image>().sprite = itemCursor.icon;
            image_cursor.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            image_cursor.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }

        // Open or Close Inventory
        if (Input.GetKeyDown(KeyCode.E))
        {
            InventoryWindow.SetActive(!InventoryWindow.activeSelf);
        }

    }

    // give player items
    public bool give(Item item)
    {
        for(int i = 0;i < 25; i++)
        {
            if(new IsNull().Judge(items[i]))
            {
                items[i] = item;
                return true;
            }
        }

        return false;
    }
}
