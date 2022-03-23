using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BehaviorStateMachine
{    
    private IBehaviorState _currentState;

    public void ChangeState(IBehaviorState newState)    
    {
        if (_currentState != null)
        {
            _currentState.OnExit();
        }        
        _currentState = newState;
        _currentState.OnEntry();
    }

    public class Factory : PlaceholderFactory<BehaviorStateMachine>
    {
        
    }
}
