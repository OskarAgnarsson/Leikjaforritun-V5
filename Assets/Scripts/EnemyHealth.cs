using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball") | collision.gameObject.CompareTag("LightningBolt"))
        {
            hp -= 1;
        }
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
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
