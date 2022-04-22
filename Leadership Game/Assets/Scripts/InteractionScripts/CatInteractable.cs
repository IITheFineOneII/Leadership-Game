using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInteractable : MonoBehaviour,IClick
{
    //removes gameobject but can be repurposed for anything involving the object

    public GameObject player;
    public GameObject cat;
    public npcMove catMoveScript;
    public bool moving;
    public bool hasSlingshot = false;
    public bool commanding;

    private void Start()
    {
        player = GameObject.Find("MC");
        cat = GameObject.Find("Cat");
        catMoveScript = cat.GetComponent<npcMove>();
        commanding = player.GetComponent<PlayerController>().Commanding;
    }

    public void onClickAction()
    {
        commanding = player.GetComponent<PlayerController>().Commanding;
        int id = player.GetComponent<PlayerController>().i;
        if (commanding == true)
        {

            if (id == 3)
            {
                if (gameObject.name == "Slingshot1")
                {
                    catMoveScript.move = true;

                }
                Debug.Log("I work only once");
                player.GetComponent<PlayerController>().ChangeCommanding();
                commanding = player.GetComponent<PlayerController>().Commanding;
            }
            else
            {
                Debug.Log("Can't");
                player.GetComponent<PlayerController>().ChangeCommanding();
                commanding = player.GetComponent<PlayerController>().Commanding;
            }
        }
    }

    private void Update()
    {
        if (catMoveScript.pathMarkers.Count == 0)
        {
            if (hasSlingshot == false)
            {
                hasSlingshot = true;
                Debug.Log(hasSlingshot);
                
                catMoveScript.pathMarkers.Add(GameObject.Find("CatPathMarker1"));
                catMoveScript.pathMarkers.Add(GameObject.Find("CatPathMarker3"));
                catMoveScript.move = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (hasSlingshot == true)
            {
                Inventory.Instance().PickUpItem(GetComponent<ItemDisplay>().item);
                //NEEDS TO BE DROPPED TO THE BROTHER FROM THE INVENTORY - TO DO
                Destroy(gameObject);
                catMoveScript.move = false;
            }
        }
    }
}
