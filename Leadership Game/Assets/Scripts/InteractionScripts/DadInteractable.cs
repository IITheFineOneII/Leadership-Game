using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadInteractable : MonoBehaviour, IClick
{
    public GameObject oldwalkway;
    public GameObject newwalkway;
    public GameObject ironBars;

    public GameObject dad;
    public npcMove dadMoveScript;

    public GameObject dadUncrouch;
    public dadUncrouch dadUncrouchScript;

    Animator animator;

    private LayerMask originalLayer;

    // List of path markers
    public GameObject pathMarkerLever;

    public bool goingToLever = false;

    private void Start()
    {
        dad = GameObject.Find("Dad");
        dadMoveScript = dad.GetComponent<npcMove>();
        animator = dad.GetComponent<Animator>();
        originalLayer = gameObject.layer;
        dadUncrouch = GameObject.Find("DadUncrouch");
        dadUncrouchScript = dadUncrouch.GetComponent<dadUncrouch>();
        ironBars = GameObject.Find("Iron bars");
    }

    //removes gameobject but can be repurposed for anything involving the object
    public void onClickAction()
    {
        GameObject player = GameObject.Find("MC");
        bool commanding = player.GetComponent<PlayerController>().Commanding;
        int id = player.GetComponent<PlayerController>().i;
        if (commanding == true)
        {

            if (id == 1)
            {
                if (gameObject.name == "WalkwayHelper")
                {
                    dadMoveScript.pathMarkers.Add(pathMarkerLever);
                    dadMoveScript.move = true;
                    goingToLever = true;
                }

                if (gameObject.name == "Pressure Plate" && !goingToLever)
                {
                    dadMoveScript.pathMarkers.Add(gameObject);
                    dadMoveScript.move = true;
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
        if (gameObject.name == "WalkwayHelper" && dadMoveScript.pathMarkers.Count == 0 && goingToLever)
        {
            dadMoveScript.swapToOriginal = false;
            dadMoveScript.move = false;
            animator.SetBool("Crouching", true);
            dad.layer = LayerMask.NameToLayer("Moving Layer");

            oldwalkway.SetActive(false);
            newwalkway.SetActive(true);

            dadUncrouchScript.checking = true;

            if (dadUncrouchScript.walkedAway && ironBars.activeInHierarchy == false)
            {
                dadUncrouchScript.checking = false;
                animator.SetBool("Crouching", false);
                dad.layer = originalLayer;
                goingToLever = false;
                dadMoveScript.swapToOriginal = true;
            }
        }
    }
}
