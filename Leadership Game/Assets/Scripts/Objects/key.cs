using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour, IClick
{
    /// <summary>
    /// Calls inventory singleton adding to list. Removing object from the scene
    /// </summary>
    public void onClickAction()
    {
        Inventory.Instance().PickUpItem(GetComponent<ItemDisplay>().item);
        Destroy(gameObject);
    }

}