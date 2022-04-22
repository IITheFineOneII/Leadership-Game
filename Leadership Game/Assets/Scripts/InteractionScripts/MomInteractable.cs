using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomInteractable : MonoBehaviour, IClick
{

    public GameObject mom;
    public npcMove momMoveScript;

    private void Start()
    {
        mom = GameObject.Find("Mum");
        momMoveScript = mom.GetComponent<npcMove>();
    }

    //removes gameobject but can be repurposed for anything involving the object
    public void onClickAction()
    {
        GameObject player = GameObject.Find("MC");
        bool commanding = player.GetComponent<PlayerController>().Commanding;
        int id = player.GetComponent<PlayerController>().i;
        if (commanding == true)
        {

            if (id == 2)
            {
                if (gameObject.name == "Crate")
                {

                    momMoveScript.move = true;

                    //gameObject.transform.position = new Vector3(6, 2, 260);
                    //ADD ANIMATION
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
        if (momMoveScript.pathMarkers.Count > 0)
        {
            if (momMoveScript.pathMarkers[0].name == "MumPathMarker2")
            {
                gameObject.transform.position = mom.transform.position + new Vector3(-2f, 1f, 0f);
            }
        }
        else
        {
            momMoveScript.move = false;
        }
    }
}
