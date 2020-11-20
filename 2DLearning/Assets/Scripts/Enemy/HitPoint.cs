using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // NOTE: 使用这个方法需要注意设置设置 Object 为 isTrigger 勾选
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<IDamageable>().GetHit(1);
        }

        if (collision.CompareTag("Bomb"))
        {

        }
    }
}
