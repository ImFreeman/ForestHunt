using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

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

    public CharacterController(
        CharacterControllerProtocol protocol,
        IInstantiator instantiator)
    {
        _instantiator = instantiator;
        var view = Resources.Load($"Characters/{protocol.ViewName}");
        _view = _instantiator.InstantiatePrefabForComponent<CharacterView>(view);
        _view.Position = protocol.Position;
        ID = protocol.ID;
        
        Walk(new Vector3(3.36f, 2.636933f, 6.72f));
    }

    public void Walk(Vector3 goal)
    {
        _view.navMeshAgent.SetDestination(goal);
    }
    
    public class Factory : PlaceholderFactory<CharacterControllerProtocol, CharacterController>
    {
        
    }
}
