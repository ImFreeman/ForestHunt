using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Game.NPC.Deer.Scripts.States;
using UnityEngine;
using Zenject;

public class FoodSearchStateProtocol
{
    public Brain Brain;    

    public FoodSearchStateProtocol(Brain brain)
    {        
        Brain = brain;
    }
}

public class FoodSearchState : BehaviorState, ITickable
{
    private readonly CharacterStorage _storage;
    private readonly Brain _brain;    
    private readonly IInstantiator _instantiator;
    private readonly TickableManager _tickableManager;
    private readonly BehaviorStateMachine _microBehaviorStateMachine;

    private WalkAroundCommand _walkAroundCommand;
    
    public FoodSearchState(FoodSearchStateProtocol protocol, IInstantiator instantiator, TickableManager tickableManager, CharacterStorage storage)
    {
        _brain = protocol.Brain;        
        _instantiator = instantiator;
        _tickableManager = tickableManager;
        _storage = storage;
        _microBehaviorStateMachine = _storage.GetCharacter(ID).MicroBehaviorStateMachine;
    }
    
    public override void OnEntry()
    {
        _tickableManager.Add(this);
        StateType = BehaviorStateType.Passive;        
    }    

    public override void OnExit()
    {
        
    }

    public void Tick()
    {
        var foodList = _brain.GetInformationAboutEnviroment(EnviromentObjectType.Food);
        if (foodList.Count > 0)
        {
            _walkAroundCommand.Cancel();

            var command = _instantiator.Instantiate<GoToObjectCommand>();
            command.Destination = foodList[0].transform.position;

            command.Do();
        }
        else
        {
            if (_walkAroundCommand == null)
            {
                _walkAroundCommand = _instantiator.Instantiate<WalkAroundCommand>();
                _walkAroundCommand.ID = ID;
                _walkAroundCommand.Do();
            }
        }
    }
}
