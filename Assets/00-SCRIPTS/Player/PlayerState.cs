using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PLayerState :IState
{
    protected float xInput;
    protected float yInput;
    protected Player player;
    protected StateMachine stateMachine;
    public PLayerState(Player _player, StateMachine _stateMachine)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
    }
    public virtual void Enter()
    {

    }
    public virtual void Exit()
    {

    }
    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    

    }
}
public class IdleState : PLayerState
{
    public IdleState(Player _player, StateMachine _stateMachine) : base(_player, _stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();

    }
    public override void Exit()
    {
        base.Exit();



    }
    public override void Update()
    {
        base.Update();
        if (xInput != 0 || yInput != 0 || player.joyTick.GetMoveVector()!=Vector3.zero)
        {
            stateMachine.ChangeState(player.moveState);

        }

    }
}
public class MoveState : PLayerState

{

    public MoveState(Player _player, StateMachine _stateMachine) : base(_player, _stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("move enter");


    }
    public override void Exit()
    {
        base.Exit();
        Debug.Log("move exit");

    }
    public override void Update()
    {
        base.Update();
        // player.rb.velocity = new Vector3(xInput, yInput).normalized * player.moveSpeed;
        player.rb.velocity = player.joyTick.GetMoveVector()*player.moveSpeed*Time.deltaTime;

        Debug.Log("move update");
        if (xInput == 0 || yInput == 0)
        {

            stateMachine.ChangeState(player.idleState);
        }


    }

}