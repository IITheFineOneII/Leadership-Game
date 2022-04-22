using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcSpriteDirection : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    private Animator animator;
    private npcMove moveScript;

    float lastx, lasty, horizontal, vertical;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        moveScript = gameObject.GetComponent<npcMove>();
        lastx = transform.position.x;
        lasty = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > lastx)
        {
            horizontal = 1;
        }
        else if (transform.position.x < lastx)
        {
            horizontal = -1;
        }

        if (transform.position.y > lasty)
        {
            vertical = 1;
        }
        else if (transform.position.y < lasty)
        {
            vertical = -1;
        }

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetBool("Moving", moveScript.move);

        lastx = transform.position.x;
        lasty = transform.position.y;
    }
}
