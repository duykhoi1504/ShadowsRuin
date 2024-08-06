using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class StateMachine 
{
    public IState state;
    public void InitState(IState _state){
        state=_state;
        state.Enter();
    }
    public void ChangeState(IState _newState){
        state.Exit();
        state=_newState;
        state.Enter();
    }


}
