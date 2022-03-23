using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public struct CharacterSpawnProtocol
{
    public Vector3 Position;
    public string Name;

    public CharacterSpawnProtocol(
        Vector3 position,
        string name)
    {
        Position = position;
        Name = name;
    }
}

public class CharacterStorage
{
    private Dictionary<GUID, CharacterController> _controllerDict = new Dictionary<GUID, CharacterController>();
    private Dictionary<GUID, BehaviorStateMachine> _stateDict = new Dictionary<GUID, BehaviorStateMachine>();
    private CharacterController.Factory _controllerfactory;
    private BehaviorStateMachine.Factory _stateMachineFactory;

    public CharacterStorage(
        CharacterController.Factory controllerfactory,
        BehaviorStateMachine.Factory stateMachineFactory)
    {
        _controllerfactory = controllerfactory;
        _stateMachineFactory = stateMachineFactory;
    }

    public void Spawn(CharacterSpawnProtocol protocol)
    {
        var guid = new GUID();        
        var controller = _controllerfactory.Create(new CharacterControllerProtocol(protocol.Position, protocol.Name, guid));
        _controllerDict.Add(guid, controller);
        _stateDict.Add(guid, _stateMachineFactory.Create(new BehaviorStateMachineProtocol(controller)));                
    }
}
