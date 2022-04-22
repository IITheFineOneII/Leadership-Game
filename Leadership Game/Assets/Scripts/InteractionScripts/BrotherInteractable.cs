using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherInteractable : MonoBehaviour, IClick
{
    public GameObject key, glass, bullet;
    npcMove bulletMove;
    bool finished = false;
    

    //removes gameobject but can be repurposed for anything involving the object

    private void Start()
    {
        bullet = GameObject.Find("Slingshot Bullet");
        bulletMove = bullet.GetComponent<npcMove>();
    }

    public void onClickAction()
    {
        GameObject player = GameObject.Find("MC");
        GameObject brother = GameObject.Find("Bro");
        bool commanding = player.GetComponent<PlayerController>().Commanding;
        int id = player.GetComponent<PlayerController>().i;
        Animator animator = brother.GetComponent<Animator>();
        if (commanding == true)
        {

            if (id == 4)
            {
                if (gameObject.name == "KeyinGlass")
                {

                    animator.SetBool("Shooting", true);


                    bullet.GetComponent<SpriteRenderer>().enabled = true;
                    bulletMove.move = true;


                    //key.SetActive(true);
                    //glass.SetActive(true);
                    //Inventory.Instance().PickUpItem(GetComponent<ItemDisplay>().item);
                    //NEEDS TO BE DROPPED TO THE DOOR FROM THE INVENTORY - TO DO
                }
                //Destroy(gameObject);
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
        if (bulletMove.pathMarkers.Count == 0 && finished == false)
        {
            key.SetActive(true);
            glass.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            bullet.GetComponent<SpriteRenderer>().enabled = false;
            key = null;
            finished = true;
        }
    }
}
