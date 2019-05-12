using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAttack : MonoBehaviour
{
    private Animator anim;
    private PlayerHealth playerHP;
    private GameObject player;
    private Rigidbody2D playerRb;
    private float dist;
    private float delayTime;
    private float direction;
    private Menu menu;
    private bool pause;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHP = player.GetComponent<PlayerHealth>();
        playerRb = player.GetComponent<Rigidbody2D>();
        menu = GameObject.FindGameObjectWithTag("IngameMenu").GetComponent<Menu>();
        delayTime = Time.fixedTime + 1.2f;
        pause = menu.menuOpen;
    }

    void FixedUpdate()
    {
        pause = menu.menuOpen;
        direction = (transform.position.x - player.transform.position.x);
        dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist <= 1.1f && Time.fixedTime > delayTime && !pause)
        {
            anim.SetFloat("Speed", 1f);
            if (playerHP.hp >0) {
                playerHP.hp -= 1;
            }
            delayTime = Time.fixedTime + 1.2f;
            if (direction < 0)
            {
                playerRb.AddForce(new Vector2(400f, 500f));
            } else
            {
                playerRb.AddForce(new Vector2(-400f, 500f));
            }
        }
    }
}
