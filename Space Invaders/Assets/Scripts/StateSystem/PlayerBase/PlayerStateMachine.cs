using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState currentState;

    public void Initialize(PlayerState startState) => currentState = startState;

    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void SetStateTimer(float duration) => currentState.stateTimer = duration;

    public void SetStateTrigger(bool state) => currentState.stateTrigger = state;
}
