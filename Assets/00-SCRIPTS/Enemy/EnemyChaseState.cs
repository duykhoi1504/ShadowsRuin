using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyChaseState : EnemyState
{
   Vector3 dir;
   float maxTimer=3f;

   float timer;

    public EnemyChaseState(Enemy _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("enterChase");
        timer=maxTimer;
    }
    public override void Update()
    {
        base.Update();
        timer-=Time.deltaTime;
    
        Vector3 dir =(Player.Instance.transform.position-enemy.transform.position).normalized;
        // enemy.transform.position+=dir*enemy.moveSpeed*Time.deltaTime; 
        enemy.SetVelocity(dir*enemy.moveSpeed*enemy.moveSpeed);
        if( timer<0){
            stateMachine.ChangeState(enemy.idleState);

        }
        if((Player.Instance.transform.position-enemy.transform.position).sqrMagnitude<enemy.attackRadious){
            stateMachine.ChangeState(enemy.attackState);
            // enemy.passAway();
            
        }
    }
   
    public override void Exit()
    {
        base.Exit();
    }
}
