using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine: MonoBehaviour
{
    public PlayerState currentPlayerState
    {
        get; set;
    }

    public void ChangeState(PlayerState newState)
    {
        currentPlayerState.ExitState();
        currentPlayerState = newState;
        string content = currentPlayerState != null ? currentPlayerState.name : "null";
        Debug.Log(content);
        currentPlayerState.EnterState();
    }
    void Start()
    {
        currentPlayerState = GetInitialState();
    }

    void Update()
    {
        currentPlayerState.UpdateLogic();
    }

    protected virtual PlayerState GetInitialState()
    {
        return null;
    }

    public void OnGUI()
    {
        
    }

}
