using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    private Animator anim;
    private float timeDelay;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timeDelay = Time.fixedTime + 1.95f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { 
            anim.SetBool("Explode", true);
            Destroy(GetComponent<CircleCollider2D>());
            Destroy(this.gameObject, 2f);
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void FixedUpdate()
    {
        if (Time.fixedTime >= timeDelay)
        {
            anim.SetBool("Explode", true);
            Destroy(this.gameObject, 1f);
            rb.velocity = new Vector2(0, 0);
        }
    }
}
