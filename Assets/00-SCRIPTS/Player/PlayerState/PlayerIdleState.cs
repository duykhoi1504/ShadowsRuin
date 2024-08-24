using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, StateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // player.rb.velocity = Vector2.zero;
        player.SetZeroVelocity();

    }
    public override void Exit()
    {
        base.Exit();



    }
    public override void Update()
    {
        base.Update();
        if (player.rb.velocity != Vector2.zero || player.joyStick1.GetMoveVector() != Vector3.zero)
        {
            stateMachine.ChangeState(player.moveState);

        }

    }
}
