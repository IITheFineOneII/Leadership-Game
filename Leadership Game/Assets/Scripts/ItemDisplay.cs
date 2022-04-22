using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Item item;
    private SpriteRenderer itemSprite;


    /// <summary>
    /// Gets the spriteRenderer and sets the items artwork to the scriptable object attached to it 
    /// </summary>
    void Start()
    {
        itemSprite = GetComponent<SpriteRenderer>();
        itemSprite.sprite = item.artWork;
    }

}