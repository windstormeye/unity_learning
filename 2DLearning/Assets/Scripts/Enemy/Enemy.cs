using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyBaseState currentState;

    [Header("Movement")]
    public float speed;
    public Transform pointA, pointB;
    public Transform targetPoint;

    public List<Transform> attackList = new List<Transform>();

    public PatrolState patrolState = new PatrolState();
    public AttackState attackState = new AttackState();

    // Start is called before the first frame update
    void Start()
    {
        // NOTE: 开始就让敌人处于巡逻状态
        TransitionToState(patrolState);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate(this);
    }

    public void TransitionToState(EnemyBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void MoveToTarget()
    {
        // NOTE: Time.deltaTime 保证在不同机型上维持相同的速度
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        FilpDirection();
    }

    // NOTE: 攻击玩家
    public void AttackAction()
    {

    }

    // NOTE: 淦炸弹
    public void SkillAction()
    {

    }

    public void FilpDirection()
    {
        if (transform.position.x < targetPoint.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    public void SwitchPoint()
    {
        if (Mathf.Abs(pointA.position.x - transform.position.x) > Mathf.Abs(pointB.position.x - transform.position.x))
        {
            targetPoint = pointA;
        }
        else
        {
            targetPoint = pointB;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!attackList.Contains(collision.transform))
        {
            attackList.Add(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attackList.Remove(collision.transform);
    }
}
