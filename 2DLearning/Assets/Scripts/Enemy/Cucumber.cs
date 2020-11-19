﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucumber : Enemy, IDamageable
{
    public void GetHit(float damage)
    {
        health -= damage;
        if (health < 1)
        {
            health = 0;
            isDead = true;
        }

        anim.SetTrigger("hit");
    }

    public void SetOff()
    {
        // NOTE: 动画
        targetPoint.GetComponent<Bomb>().TurnOff();
    }
}
