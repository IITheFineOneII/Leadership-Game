using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvUi : MonoBehaviour
{
    //This Transform calls the "UI" game object
    public Transform itemsParent;
    //Calling the invenotry script
    Inventory inventory;
    //Creating a list out of inventory slots
    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        //These functions start off the inventory
        inventory = Inventory.Instance();
        inventory.onItemChangedCallback += UpdateUI; 
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }


    void UpdateUI()
    {
        //Loops through the inventory and assigns each item to a slot
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.itemList.Count)
            {
                slots[i].AddItem(inventory.itemList[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        
    }
}
