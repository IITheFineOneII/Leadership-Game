using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NewItem", menuName ="Inventory/Item")]
///
/// This class creates objects that have attributes assigned to them
/// items that can be created with right clicking and adding objects into unity
/// these are handled by the inventory script to keep track of objects that have been picked up.
///
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public string itemDescription = "New Description";
    public Sprite artWork;
    public enum Type { Defualt, Usable, KeyItem}
    public Type type = Type.Defualt;

    public virtual void Use()
    {
        //Use the item and something might happen

        Debug.Log("Using " + name);
    }

}
