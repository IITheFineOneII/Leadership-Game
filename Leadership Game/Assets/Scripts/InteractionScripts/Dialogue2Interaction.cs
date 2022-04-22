using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue2Interaction : MonoBehaviour, IClick
{

    public void onClickAction()
    {
        GameObject Dialogue = GameObject.Find("MC");

        Dialogue.GetComponent<DialogueManager>().ContinueStory();
    }
}
