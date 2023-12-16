using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;

    protected string stateName;

    protected EnemyStateMachine stateMachine;
    
    public float stateTimer;
    public bool stateTrigger;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string stateName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }

    public virtual void Enter()
    {
        enemy.GetAnimator().SetBool(stateName, true);
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
        enemy.GetAnimator().SetBool(stateName, false);
    }
}
