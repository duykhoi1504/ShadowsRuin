using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerState : IState
{
    // protected float xInput;
    // protected float yInput;
    private string aniBoolName;
    protected Player player;
    protected bool triggerCalled;
       protected float xInput,yInput;

    protected float stateTimer;
    [SerializeField] protected float maxTimer = 3f;

    protected StateMachine stateMachine;
    public PlayerState(Player _player, StateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.aniBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        player.anim.SetBool(aniBoolName, true);
    }
    public virtual void Exit()
    {
        player.anim.SetBool(aniBoolName, false);
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput=Input.GetAxisRaw("Horizontal");
        yInput=Input.GetAxisRaw("Vertical");
        

        // player.rb.velocity = new Vector3(xInput, yInput).normalized * player.moveSpeed;


        // player.rb.velocity = player.joyStick1.GetMoveVector().normalized * player.moveSpeed;
        // if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        // {
        //     stateMachine.ChangeState(player.abilityState);
        // }

    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }

}

