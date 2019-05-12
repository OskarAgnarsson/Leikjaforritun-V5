using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    public Transform projectileSpawn;
    public GameObject lightningBoltIdle;
    public Rigidbody2D LightningBoltProjectile;
    public GameObject fireballIdle;
    public Rigidbody2D fireballProjectile;

    private string[] spellSelect;
    private bool allowFire = true;
    private string spell;
    private PlayerMovement playerMov;
    private PlayerMana playerMana;
    private Menu menu;
    private bool pause;

    void Start()
    {
        playerMov = GetComponent<PlayerMovement>();
        playerMana = GetComponent<PlayerMana>();
        menu = GameObject.FindGameObjectWithTag("IngameMenu").GetComponent<Menu>();
        pause = menu.menuOpen;

        spellSelect = new string[2];
        spellSelect[0] = "Fireball";
        spellSelect[1] = "LightningBolt";
        spell = spellSelect[0];
    }

    void Update()
    {
        pause = menu.menuOpen;
        if (Input.GetKeyDown("1") && !pause)
        {
            if (spell == spellSelect[0])
            {
                ;
            } else if (spell == spellSelect[1])
            {
                spell = spellSelect[0];
                lightningBoltIdle.SetActive(false);
                fireballIdle.SetActive(true);
            }
        }
        else if (Input.GetKeyDown("2") && !pause)
        {
            if (spell == spellSelect[1])
            {
                ;
            } else if (spell == spellSelect[0])
            {
                spell = spellSelect[1];
                fireballIdle.SetActive(false);
                lightningBoltIdle.SetActive(true);
            }
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey("left") && !pause)
        {
            if (allowFire && playerMana.mana!=0)
            {
                StartCoroutine(Cast(spell, "left"));
                playerMana.mana -= 1;
            }
        }
        else if (Input.GetKey("right") && !pause)
        {
            if (allowFire && playerMana.mana!=0)
            {
                StartCoroutine(Cast(spell, "right"));
                playerMana.mana -= 1;
            }
        }
    }

    IEnumerator Cast(string spell, string facing)
    {
        allowFire = false;
        yield return new WaitForSeconds(0.01f);
        if (spell == spellSelect[0])
        {
            Rigidbody2D spellInstance = Instantiate(fireballProjectile, projectileSpawn.position, projectileSpawn.rotation);
            if (facing=="left")
            {
                spellInstance.AddForce(new Vector2(-350, 0));
            } else if (facing=="right")
            {
                spellInstance.MoveRotation(180);
                spellInstance.AddForce(new Vector2(350, 0));
            }

        } else if (spell == spellSelect[1])
        {
            Rigidbody2D spellInstance = Instantiate(LightningBoltProjectile, projectileSpawn.position, projectileSpawn.rotation);
            if (facing == "left")
            {
                spellInstance.AddForce(new Vector2(-400, 0));
            }
            else if (facing == "right")
            {
                spellInstance.MoveRotation(180);
                spellInstance.AddForce(new Vector2(400, 0));
            }
        }
        yield return new WaitForSeconds(0.6f);
        allowFire = true;
    }
}
