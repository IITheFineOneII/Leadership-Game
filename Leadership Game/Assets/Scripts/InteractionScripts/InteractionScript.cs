using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
    
{
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
        //Checks if radius around player has objects that are interactable depending on mask.
    {
        var sphereCheck = Physics2D.OverlapCircleAll(transform.position, 1f, mask);
        foreach(var item in sphereCheck)
        {
            Debug.Log("Interactable");
        }
        //TODO Make Item class.
    }
}
