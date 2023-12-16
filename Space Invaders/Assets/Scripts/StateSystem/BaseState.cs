using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    protected Entity entity;

    protected string stateName;

    protected BaseStateMachine stateMachine;
    
    public float stateTimer;
    public bool stateTrigger;

    public BaseState(Entity entity, BaseStateMachine stateMachine, string stateName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }

    public virtual void Enter()
    {
        entity.GetAnimator().SetBool(stateName, true);
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
        entity.GetAnimator().SetBool(stateName, false);
    }
}
