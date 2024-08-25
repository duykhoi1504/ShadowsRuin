using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{
    public EnemyDeadState(Enemy _enemy, StateMachine _stateMachine, string _aniBoolName) : base(_enemy, _stateMachine, _aniBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.duration;
        // Player.Instance.TakeDamage(enemy.attackDamage);
        enemy.SetVelocity(Vector2.zero);

    }
    public override void Update()
    {
        base.Update();
        if (triggerCalled)
        {
           enemy.passAway();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
