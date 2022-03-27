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

public class Character
{
    public CharacterController Controller;
    public BehaviorStateMachine BehaviorStateMachine;

    public Character(BehaviorStateMachine behaviorStateMachine, CharacterController controller)
    {
        Controller = controller;
        BehaviorStateMachine = behaviorStateMachine;
    }
}

public class CharacterStorage
{
    private Dictionary<GUID, Character> _dict = new Dictionary<GUID, Character>();
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
        _dict.Add
        (
            guid,
            new Character
            (
                _stateMachineFactory.Create(),
                _controllerfactory.Create(new CharacterControllerProtocol(protocol.Position, protocol.Name, guid))                
            )
        );
        Debug.Log("s");
    }

    public Character GetCharacter(GUID key)
    {
        if (_dict.ContainsKey(key))
        {
            return _dict[key];
        }
        else
        {
            return null;
        }
    }   
}
