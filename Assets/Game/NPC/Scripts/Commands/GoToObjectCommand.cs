using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class GoToObjectCommand : Command, ITickable
{
    private CharacterStorage _storage;
    private CharacterView _view;
    private TickableManager _tickableManager;        
    
    public GUID ID;
    public Vector3 Destination;

    public GoToObjectCommand(TickableManager tickableManager, CharacterStorage storage)
    {        
        _tickableManager = tickableManager;
        _storage = storage;
    }
    
    public override CommandResult Do()
    {
        _view = _storage.GetCharacter(ID).View;
        _view.NavMeshAgent.SetDestination(Destination);
        _tickableManager.Add(this);
        return base.Do();
    }        
    
    public void Tick()
    {
        if (Vector3.Distance(_view.Position, Destination) <= 0.5f)
        {
            Done?.Invoke(this,EventArgs.Empty);
            _tickableManager.Remove(this);
        }
    }

    public override void Cancel()
    {
        Done?.Invoke(this,EventArgs.Empty);
        _tickableManager.Remove(this);        
    }
}
