using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(ExplodeDelay());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("Explode", true);
        Destroy(this.gameObject, 1);
    }

    IEnumerator ExplodeDelay()
    {
        yield return new WaitForSeconds(4);
        anim.SetBool("Explode", true);
        Destroy(this.gameObject,1);
    }
}
