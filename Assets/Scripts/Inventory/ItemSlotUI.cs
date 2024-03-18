using System.Collections;
using System.Collections.Generic;
using Mali.Tools;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text stackableText;
    [ReadOnly] public Item myItem;

    public void UpdateUI(Item item)
    {
        myItem = item;
        icon.sprite = item.icon;
        if (item.isStackable)
        {
            int amount = InventoryManager.singleton.currentInventory[item];
            stackableText.text = amount.ToString();
        }
        else
        {
            stackableText.text = "";
        }
    }
}
