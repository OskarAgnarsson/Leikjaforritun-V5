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

    void Start()
    {
        playerMov = GetComponent<PlayerMovement>();

        spellSelect = new string[2];
        spellSelect[0] = "Fireball";
        spellSelect[1] = "LightningBolt";
        spell = spellSelect[0];
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
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
        else if (Input.GetKeyDown("2"))
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
        if (Input.GetKey("left"))
        {
            if (allowFire)
            {
                StartCoroutine(Cast(spell, "left"));
            }
        }
        else if (Input.GetKey("right"))
        {
            if (allowFire)
            {
                StartCoroutine(Cast(spell, "right"));
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
