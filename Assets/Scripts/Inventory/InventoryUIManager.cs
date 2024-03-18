using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private ItemSlotUI[] itemSlots;

    private void UpdateUI(Item item)
    {
        //Cycle through all item slots and update their UI
        //Check for stackable
        if (item.isStackable)
        {
            foreach (ItemSlotUI slot in itemSlots)
            {
                if (slot.myItem == item)
                {
                    slot.UpdateUI(item);
                    return;
                }
            }
        }

        foreach (ItemSlotUI slot in itemSlots)
        {
            if (slot.myItem == null)
            {
                slot.UpdateUI(item);
                return;
            }
        }
    }

    private void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    #region EVENT SUBSCRIPTIONS
    private void OnEnable()
    {
        InventoryManager.OnInventoryChanged += UpdateUI;
        InputManager.OnToggleInventoryInput += ToggleInventory;
    }
    
    private void OnDisable()
    {
        InventoryManager.OnInventoryChanged -= UpdateUI;
        InputManager.OnToggleInventoryInput -= ToggleInventory;
    }
    #endregion
}
