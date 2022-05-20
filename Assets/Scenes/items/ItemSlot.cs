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
    private Item item;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager");
        inventory = inventoryManager.GetComponent<Inventory>();
        image = this.transform.Find("icon").GetComponent<Image>();
        text = this.transform.Find("amount").GetComponent<TextMeshProUGUI>();
        item = inventory.items[slot];
    }

    void FixedUpdate()
    {
        if(!new IsNull().Judge(inventory.items[slot]))
        {
            image.sprite = inventory.items[slot].icon;
            text.text = inventory.items[slot].amount.ToString();
        }
        else
        {
            image.sprite = null;
            text.text = "null_dayo";
        }
    }

    public void OnClick()
    {
        if (new IsNull().Judge(inventory.items[slot]))
        {
            if (new IsNull().Judge(inventory.itemCursor)) {
            }
            else
            {
                inventory.items[slot] = inventory.itemCursor;
                inventory.itemCursor = null;
            }
        }
        else
        {
            if(new IsNull().Judge(inventory.itemCursor))
            {
                inventory.itemCursor = inventory.items[slot];
                inventory.items[slot] = null;
            }
            else
            {
                (inventory.items[slot], inventory.itemCursor) = (inventory.itemCursor, inventory.items[slot]);
            }

        }
    }
}
