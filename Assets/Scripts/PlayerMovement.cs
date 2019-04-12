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
    private bool jump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        
        if (inputs.x * rb.velocity.x < maxSpeed)
        {
            rb.AddForce(Vector2.right * inputs.x * moveForce);
        }

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }

        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }
}
