using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

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
    public BehaviorStateMachine MacroBehaviorStateMachine;
    public CharacterView View;

    public Character(BehaviorStateMachine macroBehaviorStateMachine, CharacterView view)
    {
        View = view;        
        MacroBehaviorStateMachine = macroBehaviorStateMachine;
    }
}

public class CharacterStorage
{
    private Dictionary<GUID, Character> _dict = new Dictionary<GUID, Character>();    
    private BehaviorStateMachine.Factory _stateMachineFactory;
    private IInstantiator _instantiator;

    public CharacterStorage(        
        BehaviorStateMachine.Factory stateMachineFactory,
        IInstantiator instantiator)
    {        
        _stateMachineFactory = stateMachineFactory;
        _instantiator = instantiator;
    }

    public void Spawn(CharacterSpawnProtocol protocol)
    {
        var guid = new GUID();
        var view = Resources.Load($"Characters/{protocol.Name}");
        var character = new Character
        (           
            _stateMachineFactory.Create(),                        
            _instantiator.InstantiatePrefabForComponent<CharacterView>(view)
        );
        character.View.BrainEvent += (object sender, IBehaviorState state) =>
        {
            state.ID = guid;
            character.MacroBehaviorStateMachine.ChangeState(state);
        };
        _dict.Add
        (
            guid,
            character
        );        
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
