using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public enum BehaviorStateType
{
    Active,
    Passive
}

public class BehaviorState : IBehaviorState
{
    private BehaviorStateType _stateType;

    public GUID ID;

    public BehaviorStateType StateType
    {
        get => _stateType;
        protected set { _stateType = value; }
    }
    
    public virtual void OnEntry()
    {
        throw new NotImplementedException();
    }

    public virtual void OnExit()
    {
        throw new NotImplementedException();
    }
}
