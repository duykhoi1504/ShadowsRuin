using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy _enemy, StateMachine _stateMachine, string _aniBoolName) : base(_enemy, _stateMachine, _aniBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.duration;
        // Player.Instance.TakeDamage(enemy.attackDamage);

    }
    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(Vector2.zero);
        if ((Player.Instant.transform.position - enemy.transform.position).magnitude > enemy.attackRadious && stateTimer <= 0)
        {
            stateMachine.ChangeState(enemy.chaseState);
            // enemy.passAway();

        }
        if (stateTimer <= 0)
        {
            // //  Debug.Log("attacking " +enemy.attackDamage+ " to player  ");
            // enemy.anim.speed=enemyduration;
            stateTimer = maxTimer;
            enemy.attack();
            // Player.Instance.TakeDamage(enemy.attackDamage);
            // enemy.SetVelocity(Vector2.zero);
        }
        if (triggerCalled)
        {
            // stateMachine.ChangeState(enemy.chaseState);
            //do sonthing
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
