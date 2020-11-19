using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucumber : Enemy
{
    public void SetOff()
    {
        // NOTE: 动画
        targetPoint.GetComponent<Bomb>().TurnOff();
    }
}
