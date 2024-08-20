using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{

 



    public EnemyAttackState(Enemy _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
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
            stateTimer = maxTimer;
             enemy.attack();
            // Player.Instance.TakeDamage(enemy.attackDamage);
            // enemy.SetVelocity(Vector2.zero);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
