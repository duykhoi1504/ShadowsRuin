using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyIdleState : EnemyState
{
    Vector3 targetPos;
    float distanceRanPos;
    Vector3 dir;
  
    public EnemyIdleState(Enemy _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("enterIdle");
        PatrolRandomPos();
    }
    public override void Update()
    {
        base.Update();
        if(enemy.IsDetectPlayer()){
            stateMachine.ChangeState(enemy.chaseState);
        }
        dir=(targetPos-enemy.transform.position).normalized;
        enemy.SetVelocity(dir*enemy.moveSpeed);
        if((targetPos-enemy.transform.position).sqrMagnitude<0.01f){
             PatrolRandomPos();
        }
        
    }
    public override void Exit()
    {
        base.Exit();
    }
    void PatrolRandomPos(){
        targetPos= Random.insideUnitCircle;
    }
    
}
