using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private int currentHealth;
    private Animator anim;
    private PlayerHealth playerHP;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        currentHealth = playerHP.hp;
    }

    void Update()
    {
        currentHealth = playerHP.hp;
        anim.SetInteger("Health", currentHealth);
    }
}
