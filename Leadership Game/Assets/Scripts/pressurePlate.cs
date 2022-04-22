using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{
    // The target gameobject, which is the dad
    public GameObject target;

    // Whether the dad is currently dead
    public bool dead;

    // The time it will take for him to respawn
    public float respawnTime;

    // The current timer of him respawning
    float respawnTimer;

    // Get the dad
    public GameObject dad;

    // Grabbing the npcMove script from Dad
    public npcMove dadScript;

    // Offset of where to respawn the dad
    public float offset;

    // Sprite Images
    public Sprite closed, open;

    // Start is called before the first frame update
    void Start()
    {
        dad = GameObject.Find("Dad");
        dadScript = dad.GetComponent<npcMove>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the dead boolean is true
        if (dead)
        {
            // If the current time has passed the timer
            if (Time.time > respawnTimer)
            {
                // Respawn dad by setting his gameobject as active
                target.SetActive(true);

                // Set the dead boolean to false to stop this part from running
                dead = false;

                // Set his transform position to above the trap so that he does not fall into it again
                target.transform.position = new Vector3(transform.position.x + offset, transform.position.y + offset, target.transform.position.z);

                // Tell the npcMove script to stop moving, which changes his layer back to the original and stops the movement
                dadScript.move = false;
                dadScript.pathMarkers.Remove(dadScript.pathMarkers[0]);

                // Set the sprite to be closed
                gameObject.GetComponent<SpriteRenderer>().sprite = closed;
            }
        }
    }

    // On collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the gameobject that collided has the name dad
        if (collision.name == "Dad" && dadScript.move == true)
        {
            Debug.Log("Found dad");

            // Disable dad's gameobject
            target.SetActive(false);

            // Set the dead boolean to true to run the code in Update
            dead = true;

            // Set the sprite to be open
            gameObject.GetComponent<SpriteRenderer>().sprite = open;

            // Set the respawn timer to the current time added to the respawn time
            respawnTimer = Time.time + respawnTime;
        }
    }
}
