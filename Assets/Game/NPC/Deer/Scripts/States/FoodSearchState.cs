using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Game.NPC.Deer.Scripts.States;
using UnityEditor;
using UnityEngine;
using Zenject;

public class FoodSearchState : IBehaviorState, ITickable
{    
    private readonly Brain _brain;    
    private readonly IInstantiator _instantiator;
    private readonly TickableManager _tickableManager;    

    private WalkAroundCommand _walkAroundCommand;

    private List<ICommand> _commands = new List<ICommand>();
    
    public FoodSearchState(Brain brain, IInstantiator instantiator, TickableManager tickableManager)
    {
        _brain = brain;        
        _instantiator = instantiator;
        _tickableManager = tickableManager;        
    }

    public GUID ID { get; set; }

    public void OnEntry()
    {
        _tickableManager.Add(this);        
    }    

    public void OnExit()
    {
        foreach (var command in _commands)
        {
            command.Cancel();
        }
    }

    public void Tick()
    {
        var foodList = _brain.GetInformationAboutEnviroment(EnviromentObjectType.Food);
        if (foodList.Count > 0)
        {
            _walkAroundCommand.Cancel();            
            var command = _instantiator.Instantiate<GoToObjectCommand>();
            command.Destination = foodList[0].transform.position;
            _commands = new List<ICommand>();
            _commands.Add(command);
            command.Do();
        }
        else
        {
            if (_walkAroundCommand == null)
            {
                _walkAroundCommand = _instantiator.Instantiate<WalkAroundCommand>();
                _commands.Add(_walkAroundCommand);
                _walkAroundCommand.ID = ID;
                _walkAroundCommand.Do();
            }
        }
    }
}
