using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : PlayerStateMachine
{
    public PlayerIdling  idleState;
    public PlayerWalking walkState;

    private void Awake()
    {
        idleState = new PlayerIdling (this);
        walkState = new PlayerWalking(this);
    }

    protected override PlayerState GetInitialState()
    {
        return idleState;
    }

}
