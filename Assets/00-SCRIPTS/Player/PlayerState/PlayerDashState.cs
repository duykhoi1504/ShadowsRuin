using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{


    public PlayerDashState(Player _player, StateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
        // player.rb.velocity = Vector2.zero;
        // AbilityManager.Instant.abilityDatas[0].ability.Use();


    }
    public override void Update()
    {
        base.Update();
        Debug.Log(player.currentDir + " curetn dir");
        player.rb.AddForce(player.currentDir.normalized *player.dashSpeed);
        if (stateTimer <= 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }



}
