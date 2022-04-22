using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dadUncrouch : MonoBehaviour
{

    public bool walkedAway = false, checking = false;

    private void Start()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && checking == true)
        {
            walkedAway = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && checking == true)
        {
            walkedAway = true;
        }
    }
}
