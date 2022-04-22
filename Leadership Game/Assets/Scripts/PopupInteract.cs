using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PopupInteract : MonoBehaviour
{
    public UnityEvent dialogueStart;
    public bool inRange;
    public UnityEvent interactAction;
    public UnityEvent leaveAction;
    //Adds objects that are near by to a list (great for bug fixing btw)
    [SerializeField] private List<GameObject> nearbyObjects = new List<GameObject>();
    //If close to 2 ore more objects the popup text would stay disabled if u exited the range of objects near eachother.
    // Update is called once per frame
    //void Update()
    //{
    //    if (inRange)
    //    {
    //        interactAction.Invoke();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            //inRange = true;
            //adds items to the serialize field
            nearbyObjects.Add(collision.gameObject);
            // Debug.Log("Player now in range");

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject player = GameObject.Find("MC");
        if (collision.gameObject.CompareTag("Character") || collision.gameObject.CompareTag("Item") || collision.gameObject.CompareTag("Lever") || collision.gameObject.CompareTag("InventoryInteractable"))
        {
            interactAction.Invoke();
        }

        if (collision.gameObject.CompareTag("Character") || collision.gameObject.CompareTag("Item") || collision.gameObject.CompareTag("Lever") || collision.gameObject.CompareTag("InventoryInteractable"))
           
            if (player.GetComponent<DialogueManager>().dialoguePlaying)
            {
                dialogueStart.Invoke();
            }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Character") || collision.gameObject.CompareTag("Item") || collision.gameObject.CompareTag("Lever") || collision.gameObject.CompareTag("InventoryInteractable"))
        {
            inRange = false;
            //removes items from list to prevent clutter
            nearbyObjects.Remove(collision.gameObject);
            Debug.Log("Player now out of range");
            leaveAction.Invoke();
        }
    }

}