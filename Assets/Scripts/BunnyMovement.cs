using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private float dist;
    private bool facingLeft = true;
    private Animator anim;
    private Vector2 velocity;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        velocity = new Vector2(1f, 0);
    }


    void FixedUpdate()
    {
        dist = Vector2.Distance(transform.position,player.transform.position);
        if (dist <= 11f)
        {
            if (transform.position.x - player.transform.position.x < 0)
            {
                rb.MovePosition(rb.position + velocity * 2.5f * Time.fixedDeltaTime);
                if (facingLeft)
                {
                    Flip();
                }
                anim.SetFloat("Speed", 1f);
            } else if (transform.position.x - player.transform.position.x > 0)
            {
                rb.MovePosition(rb.position - velocity * 3.25f * Time.fixedDeltaTime);
                if (!facingLeft)
                {
                    Flip();
                }
                anim.SetFloat("Speed", 1f);
            }
        } else
        {
            anim.SetFloat("Speed", 0);
        }

    }

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
