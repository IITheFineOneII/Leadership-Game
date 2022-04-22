using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    Item item;
    public void AddItem (Item newItem)
    {
        //This function visualises the object within the inventory (Makes the sprite show up)
        item = newItem;
        icon.sprite = item.artWork;
        icon.enabled = true;
    }
    public void ClearSlot()
    {
        //This function removes object from the inventory once its gone
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        //This function calls object's ability to do something (Currently Nothing! :P )
        if (item != null)
        {
            item.Use();
        }
    }
}
