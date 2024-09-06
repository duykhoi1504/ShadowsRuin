using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState

{
    public PlayerMoveState(Player _player, StateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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
        // player.rb.velocity = player.joyStick1.GetMoveVector() * player.moveSpeed*Time.deltaTime;
        //  player.rb.velocity = player.joyStick1.GetMoveVector().normalized * player.moveSpeed;
        Vector2 movement=new Vector2(xInput,yInput);

         player.rb.velocity =movement.normalized * player.moveSpeed;


        if (xInput==0 && yInput==0)
        {

            stateMachine.ChangeState(player.idleState);
        }
    }

}