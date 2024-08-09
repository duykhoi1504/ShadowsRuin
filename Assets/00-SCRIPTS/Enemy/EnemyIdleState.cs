using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyIdleState : EnemyState
{
    Vector3 targetPos;
    float distanceRanPos;
    Vector3 dirPatrol;
  
    public EnemyIdleState(Enemy _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("enterIdle");

        PatrolRandomPos();
      
         enemy.animIndicator(enemy.spawnIndicator.gameObject);
         
    }
    public override void Update()
    {
        base.Update();


        if(!enemy.isSpawned)return;


        if(enemy.IsDetectPlayer()){
            stateMachine.ChangeState(enemy.chaseState);
        }
        
        dirPatrol=(targetPos-enemy.transform.position).normalized;
        
        enemy.SetVelocity(dirPatrol*enemy.moveSpeed);
        
        distanceRanPos=(targetPos-enemy.transform.position).sqrMagnitude;
        
        if(distanceRanPos<0.01f){
             PatrolRandomPos();
            //  Debug.Log(targetPos);
        }
        
    }
    public override void Exit()
    {
        base.Exit();
    }
    private Vector3 PatrolRandomPos(){
        targetPos=(Vector2)enemy.transform.position + Random.insideUnitCircle*enemy.chaseRadious;
        return targetPos;
    }
    
}
