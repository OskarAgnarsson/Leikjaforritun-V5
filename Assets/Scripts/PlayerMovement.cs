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
    private int jumpCount = 0;
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

        if (grounded)
        {
            jumpCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            jumpCount += 1;
            jump = true;
        } else if (Input.GetKeyDown(KeyCode.W)  && jumpCount <= 1)
        {
            jumpCount += 1;
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
        //Þessi haugur af if statementum fyrir neðan leyfir player að skjóta í báðar áttir og hreyfast í báðar áttir á sama tíma
        if (inputs.x > 0 && facingLeft)
        {
            if (Input.GetKey("right"))
            {
                Flip();
            }
            else if (Input.GetKey("left"))
            {
                ;
            }
            else
            {
                Flip();
            }
        }
        else if (inputs.x > 0 && !facingLeft)
        {
            if (Input.GetKey("left"))
            {
                Flip();
            } else if (Input.GetKey("right"))
            {
                ;
            } else
            {
                ;
            }
        }
        else if (inputs.x < 0 && !facingLeft)
        {
            if (Input.GetKey("left"))
            {
                Flip();
            } else if (Input.GetKey("right"))
            {
                ;
            } else
            {
                Flip();
            }
        }
        else if (inputs.x < 0 && facingLeft)
        {
            if (Input.GetKey("right"))
            {
                Flip();
            } else if (Input.GetKey("left"))
            {
                ;
            } else
            {
                ;
            }
        }
        else if (inputs.x == 0 && facingLeft)
        {
            if (Input.GetKey("right"))
            {
                Flip();
            }
            else
            {
                ;
            }
        }
        else if (inputs.x == 0 && !facingLeft)
        {
            if (Input.GetKey("left"))
            {
                Flip();
            }
            else
            {
                ;
            }
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
