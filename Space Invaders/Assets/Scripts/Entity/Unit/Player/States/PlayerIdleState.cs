using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{

    public PlayerIdleState(Player entity, PlayerStateMachine stateMachine, string stateName) : base(entity, stateMachine, stateName)
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
    }
    public override void Exit()
    {
        base.Exit();
    }
}
