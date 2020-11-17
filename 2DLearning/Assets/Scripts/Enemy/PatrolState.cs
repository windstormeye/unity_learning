using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyBaseState
{
    // NOTE: 进入状态要做什么
    public override void EnterState(Enemy enemy)
    {
        enemy.animState = 0;
        // NOTE: 切换当前巡逻点
        enemy.SwitchPoint();
    }

    // NOTE: 状态中要做什么
    public override void OnUpdate(Enemy enemy)
    {
        if (!enemy.anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            enemy.animState = 1;
            enemy.MoveToTarget();
        }

        if (Mathf.Abs(enemy.transform.position.x - enemy.targetPoint.position.x) < 0.01f)
        {
            enemy.TransitionToState(enemy.patrolState);
        }
        
        if (enemy.attackList.Count > 0)
        {
            //enemy.TransitionToState(enemy.attackState);
        }
    }
}
