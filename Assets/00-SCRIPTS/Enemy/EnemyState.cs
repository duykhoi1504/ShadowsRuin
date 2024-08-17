using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : IState
{
    protected Enemy enemy;
    protected StateMachine stateMachine;
    protected bool triggerCalled;
    protected float stateTimer;
       [SerializeField]protected float maxTimer = 3f;

    public EnemyState(Enemy _enemy, StateMachine _stateMachine)
    {
        enemy = _enemy;
        stateMachine = _stateMachine;
    }
    public virtual void Enter()
    {
        triggerCalled = false;
    }
    public virtual void Update()
    {
        // Debug.Log("timer"+stateTimer);
        stateTimer -= Time.deltaTime;
    }
    public virtual void Exit()
    {

    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }

}
