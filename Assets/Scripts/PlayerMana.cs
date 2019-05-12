using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int mana;

    private float delayTime;

    void Start()
    {
        mana = 5;
        delayTime = 2f + Time.time;
    }

    void Update()
    {

        if (mana < 5 && Time.time > delayTime)
        {
            mana += 1;
            delayTime = 2f + Time.time;
        }
    }
}
