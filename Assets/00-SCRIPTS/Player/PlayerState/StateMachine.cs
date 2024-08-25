using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class StateMachine 
{
    public IState currentState;
    public void InitState(IState _state){
        currentState=_state;
        currentState.Enter();
    }
    public void ChangeState(IState _newState){
        currentState.Exit();
        currentState=_newState;
        currentState.Enter();
    }


}
