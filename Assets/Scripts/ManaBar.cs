using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    private int currentMana;
    private Animator anim;
    private PlayerMana playerMana;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>();
        currentMana = playerMana.mana;
    }

    void Update()
    {
        currentMana = playerMana.mana;
        anim.SetInteger("Mana", currentMana);
    }
}
