﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{

    public PlayerDeadState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
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
