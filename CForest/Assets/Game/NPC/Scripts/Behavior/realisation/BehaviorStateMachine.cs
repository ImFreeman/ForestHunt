using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public struct BehaviorStateMachineProtocol
{
    public CharacterController CharacterController;

    public BehaviorStateMachineProtocol(CharacterController characterController)
    {
        CharacterController = characterController;
    }
}

public class BehaviorStateMachine
{
    private CharacterController _characterController;
    
    public BehaviorStateMachine(BehaviorStateMachineProtocol protocol)
    {
        _characterController = protocol.CharacterController;
    }

    public class Factory : PlaceholderFactory<BehaviorStateMachineProtocol, BehaviorStateMachine>
    {
        
    }
}
