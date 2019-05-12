using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hp;

    void Start()
    {
        hp = 5;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HeartPickup") && hp < 5)
        {
            hp += 1;
            Destroy(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= -35)
        {
            hp = 0;
        }
    }
}
