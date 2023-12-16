using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    // States
    public PlayerStateMachine stateMachine;
    
    public PlayerIdleState idleState;
    public PlayerMoveState moveState;

    public PlayerDyingState dyingState;
    public PlayerDeadState deadState;
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        stateMachine = new PlayerStateMachine();
        
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");

        dyingState = new PlayerDyingState(this, stateMachine, "Dying");
        deadState = new PlayerDeadState(this, stateMachine, "Dead");
        
        stateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public void SetStateTimer(float duration) => stateMachine.SetStateTimer(duration);
    public void SetStateTrigger(bool flag) => stateMachine.SetStateTrigger(flag);
}
