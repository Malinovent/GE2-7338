using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Create New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public bool isStackable = false;

    public virtual void UseItem()
    {
        Debug.Log("Used " + itemName);
    }
}


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Create New Weapon Item")]
public class WeaponItem : Item
{
   
}