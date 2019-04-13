using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float maxSpeed = 5f;
    public float moveForce = 365f;
    public float jumpForce = 1000f;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private Vector2 inputs = Vector2.zero;
    private bool grounded = false;
    private bool jump = false;
    private bool facingLeft = true;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        inputs = Vector2.zero;
        inputs.x = Input.GetAxis("Horizontal");

        anim.SetFloat("Velocity",Mathf.Abs(inputs.x*3));
        
        if (inputs.x * rb.velocity.x < maxSpeed)
        {
            rb.AddForce(Vector2.right * inputs.x * moveForce);
        }

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }

        if (inputs.x > 0 && facingLeft)
        {
            Flip();
        } else if (inputs.x < 0 && !facingLeft)
        {
            Flip();
        }

        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = false;
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
