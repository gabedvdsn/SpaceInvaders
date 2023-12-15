using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDyingState : PlayerState
{
    public PlayerDyingState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
    }
    protected override void HandleInput()
    {
        base.HandleInput();
    }
    protected override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (stateTrigger) stateMachine.ChangeState(player.deadState);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
