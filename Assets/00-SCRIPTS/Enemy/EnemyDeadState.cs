using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Khoidev
{
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


        }
        public override void Update()
        {
            base.Update();

        }

        public override void Exit()
        {
            base.Exit();

        }
    }
}