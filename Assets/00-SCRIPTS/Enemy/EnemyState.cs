using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : IState
{
    protected Enemy enemy;
    private string aniBoolName;
    protected StateMachine stateMachine;
    protected bool triggerCalled;
    protected float stateTimer;
    [SerializeField] protected float maxTimer = 3f;

    public EnemyState(Enemy _enemy, StateMachine _stateMachine, string _aniBoolName)
    {
        stateMachine = _stateMachine;
        enemy = _enemy;
        aniBoolName = _aniBoolName;
    }
    public virtual void Enter()
    {
        triggerCalled = false;
        enemy.anim.SetBool(aniBoolName, true);
    }
    public virtual void Update()
    {
        // Debug.Log("timer"+stateTimer);
        stateTimer -= Time.deltaTime;
    }
    public virtual void Exit()
    {
        enemy.anim.SetBool(aniBoolName, false);

    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }

}
