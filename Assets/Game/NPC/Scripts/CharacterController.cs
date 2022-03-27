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

public class CharacterController
{
    private CharacterView _view;
    private IInstantiator _instantiator;
    private GUID ID;    
    private Random _random = new Random();
    

    public CharacterController(
        CharacterControllerProtocol protocol,
        IInstantiator instantiator)
    {
        _instantiator = instantiator;
        var view = Resources.Load($"Characters/{protocol.ViewName}");
        _view = _instantiator.InstantiatePrefabForComponent<CharacterView>(view);
        _view.Position = protocol.Position;
        ID = protocol.ID;
        DOVirtual.DelayedCall(0.001f, () =>
        {
            _view.ID = ID;
        });        
        
        //Walk(new Vector3(3.36f, 2.636933f, 6.72f));
    }    

    public void Walk(Vector2 goal)
    {
        var pos = _view.Position;
        pos.x += goal.x;
        pos.z += goal.y;
        _view.NavMeshAgent.SetDestination(pos);
    }


    public void Eat()
    {
        Debug.Log("Ест");
    }
    
    public class Factory : PlaceholderFactory<CharacterControllerProtocol, CharacterController>
    {
        
    }    
}
