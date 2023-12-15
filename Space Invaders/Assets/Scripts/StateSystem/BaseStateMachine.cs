using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine
{
    public BaseState currentState;

    public void Initialize(BaseState startState) => currentState = startState;

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void SetStateTimer(float duration) => currentState.stateTimer = duration;

    public void SetStateTrigger(bool state) => currentState.stateTrigger = state;
}
