using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteDirection : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", rigid.velocity.x);
        animator.SetFloat("Vertical", rigid.velocity.y);
        animator.SetFloat("Speed", rigid.velocity.magnitude);
    }
}
