using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public int slot;

    private GameObject inventoryManager;
    private Inventory inventory;
    private Image image;
    private TextMeshProUGUI text;
    // private Item item;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager");
        inventory = inventoryManager.GetComponent<Inventory>();
        image = this.transform.Find("icon").GetComponent<Image>();
        text = this.transform.Find("amount").GetComponent<TextMeshProUGUI>();
        // item = inventory.items[slot];
    }

    void FixedUpdate()
    {
         if(inventory.items[slot] != null)
        {
            image.sprite = inventory.items[slot].icon;
            text.text = inventory.items[slot].amount.ToString();
        }
        else
        {
            image.sprite = null;
            text.text = null;
        }
    }

    public void OnClick()
    {
        if (inventory.items[slot] == null)
        {
            if (inventory.item_cursor == null) {
            }
            else
            {
                inventory.items[slot] = inventory.item_cursor;
                inventory.item_cursor = null;
            }
        }
        else
        {
            if(inventory.item_cursor == null)
            {
                inventory.item_cursor = inventory.items[slot];
                inventory.items[slot] = null;
            }
            else
            {
                (inventory.items[slot], inventory.item_cursor) = (inventory.item_cursor, inventory.items[slot]);
            }

        }
    }
}
