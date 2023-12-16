using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;

    protected string stateName;

    protected PlayerStateMachine stateMachine;
    
    public float stateTimer;
    public bool stateTrigger;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string stateName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }

    public virtual void Enter()
    {
        player.GetAnimator().SetBool(stateName, true);
    }

    public void Update()
    {
        HandleInput();
        LogicUpdate();
    }

    protected virtual void HandleInput()
    {
        
    }

    protected virtual void LogicUpdate()
    {
        
    }

    public virtual void Exit()
    {
        player.GetAnimator().SetBool(stateName, false);
    }
}
