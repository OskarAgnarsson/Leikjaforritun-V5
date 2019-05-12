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
    private float heightDiff;
    private PlayerMovement playerMov;
    private Menu menu;
    private bool pause;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerMov = player.GetComponent<PlayerMovement>();
        menu = GameObject.FindGameObjectWithTag("IngameMenu").GetComponent<Menu>();
        velocity = new Vector2(1f, 0);
        pause = menu.menuOpen;
    }


    void FixedUpdate()
    {
        pause = menu.menuOpen;
        heightDiff = transform.position.y - player.transform.position.y;
        dist = Vector2.Distance(transform.position,player.transform.position);
        if (dist <= 11f && dist > 1.1f && Mathf.Abs(heightDiff) < 1 && !pause)
        {
            if (transform.position.x - player.transform.position.x < 0)
            {
                rb.MovePosition(rb.position + velocity * 3.25f * Time.fixedDeltaTime);
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
        } else if (dist <= 11f && dist > 1.1f && Mathf.Abs(heightDiff) < 7f && !playerMov.grounded && !pause)
        {
            if (transform.position.x - player.transform.position.x < 0)
            {
                rb.MovePosition(rb.position + velocity * 3.25f * Time.fixedDeltaTime);
                if (facingLeft)
                {
                    Flip();
                }
                anim.SetFloat("Speed", 1f);
            }
            else if (transform.position.x - player.transform.position.x > 0)
            {
                rb.MovePosition(rb.position - velocity * 3.25f * Time.fixedDeltaTime);
                if (!facingLeft)
                {
                    Flip();
                }
                anim.SetFloat("Speed", 1f);
            }
        }
        else if (dist <= 11f && dist > 1.1f && Mathf.Abs(heightDiff) >= 1 && playerMov.grounded && !pause)
        {
            anim.SetFloat("Speed", 0);
        } else if (dist > 11f | dist < 1.1f && !pause)
        {
            anim.SetFloat("Speed", 0);
        }
        else if (pause)
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
