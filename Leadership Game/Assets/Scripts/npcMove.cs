using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMove : MonoBehaviour
{

    // The speed at which they'll move
    public float speed = 0.5f;

    // Whether they should move or not
    public bool move;

    // Offset so that they don't go inside the object
    public Vector2 offset;

    // Layer to switch back to
    private LayerMask originalLayer;

    // Rigidbody
    private Rigidbody2D rb;

    // List of path markers
    public List<GameObject> pathMarkers;

    // Bool to toggle checking for layer swap incase layer needs to be specifically set
    public bool swapToOriginal = true;

    // Start is called before the first frame update
    void Start()
    {
        originalLayer = gameObject.layer;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void moveFunc(GameObject target)
    {
        // Change Layer to special layer that doesnt collide with things.
        gameObject.layer = LayerMask.NameToLayer("Moving Layer");

        // Offset is added incase we don't want the NPC to step ontop of the target
        Vector3 moveTo = new Vector3(target.transform.position.x + offset.x, target.transform.position.y + offset.y, transform.position.z);
        // Vector for moving towards target from NPC's position at set speed
        Vector2 moveVector2D = Vector2.MoveTowards(transform.position, moveTo, speed * Time.deltaTime);
        // Change the vector to 3D as transform.position is in 3D and will change the NPC's Z. Instead, we use their transform Z
        Vector3 moveVector3D = new Vector3(moveVector2D.x, moveVector2D.y, transform.position.z);
        // Apply MoveTowards vector to transform position
        transform.position = moveVector3D;
    }
    void Update()
    {
        // If we want the NPC to move
        if (move)
        {
            if (pathMarkers.Count > 0)
            {
                moveFunc(pathMarkers[0]);

                if (Math.Round(transform.position.x) == Math.Round(pathMarkers[0].transform.position.x) && Math.Round(transform.position.y) == Math.Round(pathMarkers[0].transform.position.y))
                {
                    pathMarkers.Remove(pathMarkers[0]);
                }
            }
        }
        else
        {
            if (swapToOriginal)
            {
                // Switch back to original layer when not moving
                gameObject.layer = originalLayer;
            }
        }
    }
}
