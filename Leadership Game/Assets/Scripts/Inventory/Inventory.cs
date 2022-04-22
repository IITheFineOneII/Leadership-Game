using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    /// <summary>
    /// Creates a singleton
    /// </summary>
    private static Inventory _instance;
    
    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("More than one Inventory Instance found!");
            return;
        }

        _instance = this;
    }
    #endregion
    /// <summary>
    /// calls singelton instance (use this to access inventory <3)
    /// </summary>
    /// <returns></returns>
    /// 
    public static Inventory Instance()
    {
        if (_instance == null) { _instance = new Inventory(); }
        return _instance;
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    
    public List<Item> itemList = new List<Item>();

    /// <summary>
    /// Adds item to player inventory.
    /// </summary>
    /// <param name="itemToAdd"></param>
    public void PickUpItem(Item itemToAdd)
    {
        itemList.Add(itemToAdd);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

    }
    public void UseUpItem(Item itemToAdd)
    {
        itemList.Remove(itemToAdd);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
