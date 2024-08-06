using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : IState
{
    public Enemy enemy;
    public StateMachine stateMachine;
 
    public EnemyState (Enemy _enemy, StateMachine _stateMachine){
        enemy=_enemy;
        stateMachine=_stateMachine;  
    }
    public virtual void Enter(){
       
    }
    public virtual void Update(){

    }
    public virtual void Exit(){

    }

}
