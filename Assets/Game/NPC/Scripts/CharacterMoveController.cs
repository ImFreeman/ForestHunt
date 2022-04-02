using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using Zenject;
using Random = System.Random;

public struct CharacterControllerProtocol
{
    public GUID ID;
    public Vector3 Position;
    public string ViewName;

    public CharacterControllerProtocol(Vector3 position, string viewName, GUID id)
    {
        Position = position;
        ViewName = viewName;
        ID = id;
    }
}

public class CharacterMoveController : BehaviorStateMachine
 {
    private CharacterView _view;
    private IInstantiator _instantiator;
    private GUID ID;    
    private Random _random = new Random();
    

    public CharacterMoveController(
        CharacterControllerProtocol protocol,
        IInstantiator instantiator)
    {
        _instantiator = instantiator;
        var view = Resources.Load($"Characters/{protocol.ViewName}");
        _view = _instantiator.InstantiatePrefabForComponent<CharacterView>(view);
        _view.Position = protocol.Position;
        ID = protocol.ID;                                
    }    

    public void WalkTo(Vector3 goal)
    {        
        _view.NavMeshAgent.SetDestination(goal);                
    }

    public void WalkAround()
    {
        var pos = _view.Position;
        var x = _random.Next(0, 10);
        var z = _random.Next(0, 10);
        pos.x += x;
        //pos.z += z;
        WalkTo(pos);
    }


    public void Eat()
    {
        Debug.Log("Ест");
    }
    
    public class Factory : PlaceholderFactory<CharacterControllerProtocol, CharacterMoveController>
    {
        
    }    
}
