using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalking : PlayerState
{

    public PlayerWalking(MovementSM stateMachine): base("PlayerWalking", stateMachine){}

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical   = Input.GetAxis ("Vertical");

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput   = !Mathf.Approximately (vertical,   0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        if(!isWalking)
        {
            playerStateMachine.ChangeState(((MovementSM) playerStateMachine).idleState);
        }
    }
}
