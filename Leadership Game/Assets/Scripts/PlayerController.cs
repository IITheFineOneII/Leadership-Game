using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private PlayerInputMap controls;
    Vector2 moveInput;

    private Rigidbody2D rigid;
    public int i = 0;

    public LayerMask mask;

    public LayerMask interact;

    bool playerInteract;

    public bool Commanding;
    public GameObject ironbars;
    public Inventory inventory;

    //Passive Cursor state
    public Texture2D cursor;

    //Cursor State once clicked
    public Texture2D cursorClicked;

    public TextAsset broJSON;
    public TextAsset doorJSON;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called 50 times a second - better for physics 

    private void FixedUpdate()
    {
        rigid.velocity = moveInput * speed;

    }
    //reads value from player input and allows for movement.

    //if the game object has the tag "Character" It will execute the following code.
    private void CharacterTrigger(Collider2D @object)
    {

        if (@object.gameObject.CompareTag("Character"))
        {
            Debug.Log("Character");
            Debug.Log(@object.name);
            Characters target = @object.GetComponent<Characters>();
            GameObject player = GameObject.Find("MC");
            //Opens the Specific Character menu that has been interacted with - Shaq's Correct interpretation (Comment code pls)
            if (!player.GetComponent<DialogueManager>().dialoguePlaying)
            {
                target.intmenu.SetActive(true);
                i = target.characterID;
            }


        }
        if (@object.gameObject.CompareTag("Lever"))
        {
            Debug.Log("Lever");
            LeverInteraction target = @object.GetComponent<LeverInteraction>();
            if (target.door.activeInHierarchy)
            {
                target.door.SetActive(false);
            }
            else if (!target.door.activeInHierarchy)
            {
                target.door.SetActive(true);
            }
        }
        
        if (@object.CompareTag("InventoryInteractable"))
        {
            bool hasitem = false;
            Debug.Log("InventoryInteractable");
            //Inventory which is now part of the MC is searched for
            GameObject inventory = GameObject.Find("MC");
            //This string is the name of the item the object requires
            string target = @object.GetComponent<InventoryInteraction>().target;
            //Calling the inventory item list
            List<Item> bag = inventory.GetComponent<Inventory>().itemList;
            //Looping through the items within inventory
            foreach (var item in bag)
            {
                if (item.itemName == target)
                {
                    //Victory Door Interaction
                    if (target == "Key" && ironbars.active == false)
                    { 
                        inventory.GetComponent<Inventory>().UseUpItem(item); //Removes item from inventory
                        hasitem = true; //We have found the item
                        SceneManager.LoadScene("Victory");
                    }
                    //Brother Interaction
                    if (target == "Sling")
                    {
                        @object.tag = "Character";
                        hasitem = true; //We have found the item
                        inventory.GetComponent<Inventory>().UseUpItem(item); //Removes item from inventory
                    }
                }
            }
            //Case for situations where you dont have the right item with you - should call a dialogue prompt
            if (bag.Count == 0 || hasitem == false)
            {
                if (target == "Sling")
                {
                    //Debug.Log("Here he should say that he cannot help you since he misplaced his sling.");
                    inventory.GetComponent<DialogueManager>().EnterDialogueMode(broJSON);
                }
                if (target == "Key")
                {
                    //Debug.Log("Here it should say that the door is locked.");
                    inventory.GetComponent<DialogueManager>().EnterDialogueMode(doorJSON);

                }
            }
            hasitem = false; //The bool needs to go back to false when we are done else this script cant be reused
        }

    }
    
    public void CommandCharacter()
    {
        Commanding = true;
    }

    public void ChangeCommanding()
    {
        if (Commanding == true)
        {
            Commanding = false;
        }
        else
        {
            Commanding = true;
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();


    }
    //When Interact button is presssed it will activate the following code
    public void Interact(InputAction.CallbackContext context)
    {
        //Builds a sphere similiar to a raycast but checks for objects all around it.
        var sphereCheck = Physics2D.OverlapCircleAll(transform.position, 1.5f, mask);
        //Will check for all objects in the sphere and will see which corrisponding function works with it
        foreach (var item in sphereCheck)
        {
            CharacterTrigger(item);
        }
        if (!context.performed)
            return;
    }
}
 