using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class BehaviorState : IBehaviorState
{        
    public GUID ID { get; set; }

    public virtual void OnEntry()
    {
        throw new NotImplementedException();
    }

    public virtual void OnExit()
    {
        throw new NotImplementedException();
    }
}
