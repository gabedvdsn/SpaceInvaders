using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState currentState;

    public void Initialize(EnemyState startState) => currentState = startState;

    public void ChangeState(EnemyState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void SetStateTimer(float duration) => currentState.stateTimer = duration;

    public void SetStateTrigger(bool state) => currentState.stateTrigger = state;
}
