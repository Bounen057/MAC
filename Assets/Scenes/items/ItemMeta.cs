using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manage own information of its item
[CreateAssetMenu(fileName = "ItemMeta", menuName = "ScriptableObjects/ItemMeta")]
public class ItemMeta : ScriptableObject
{ 
    public string itemName;
    public int id;
    public Sprite icon;
    public string[] lore;
}
