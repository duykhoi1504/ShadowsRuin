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
        if( timer<0){
            stateMachine.ChangeState(enemy.idleState);
        }
    
         dir =(Player.Instance.transform.position-enemy.transform.position).normalized;
        // enemy.transform.position+=dir*enemy.moveSpeed*Time.deltaTime; 
        enemy.SetVelocity(dir*enemy.moveSpeed*enemy.moveSpeed);
        if((Player.Instance.transform.position-enemy.transform.position).magnitude<enemy.attackRadious){
            stateMachine.ChangeState(enemy.attackState);
            // enemy.passAway();
            
        }
    }
   
    public override void Exit()
    {
        base.Exit();
    }
}
