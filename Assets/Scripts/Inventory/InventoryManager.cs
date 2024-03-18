using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    
    public Dictionary<Item, int> currentInventory = new Dictionary<Item, int>();
    
    public static event Action<Item> OnInventoryChanged;

    public List<Item> startingItems = new List<Item>();
    
    #region Singleton
    public static InventoryManager singleton;
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
    
    private void Start()
    {
        foreach (Item item in startingItems)
        {
            AddItem(item);
        }
    }
    
    private void AddItem(Item newItem, int amount = 1)
    {
        if (!currentInventory.ContainsKey(newItem))
        {
            //Item did not exist, adding it to the inventory
            currentInventory.Add(newItem, amount);
        }
        else
        {
            //Item already exists, simply changing the amount
            currentInventory[newItem] += amount;
        }
        
        OnInventoryChanged?.Invoke(newItem);
    }

    private void RemoveItem(Item itemToRemove, int amount = 1)
    {
        if (currentInventory.ContainsKey(itemToRemove))
        {
            currentInventory[itemToRemove] -= amount;
            if(currentInventory[itemToRemove] <= 0)
            {
                currentInventory.Remove(itemToRemove);
            }
            
            OnInventoryChanged?.Invoke(itemToRemove);
        }
        
        
    }
}
