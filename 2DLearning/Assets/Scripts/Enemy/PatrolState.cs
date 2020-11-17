

using UnityEngine;

public class PatrolState : EnemyBaseState
{
    // NOTE: 进入状态要做什么
    public override void EnterState(Enemy enemy)
    {
        // NOTE: 切换当前巡逻点
        enemy.SwitchPoint();
    }

    // NOTE: 状态中要做什么
    public override void OnUpdate(Enemy enemy)
    {
        if (Mathf.Abs(enemy.transform.position.x - enemy.targetPoint.position.x) < 0.01f)
        {
            enemy.SwitchPoint();
        }
        else
        {
            enemy.MoveToTarget();
        }

    }
}
