using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class FoodSearchStateProtocol
{
    public Brain Brain;
    public CharacterController CharacterController;

    public FoodSearchStateProtocol(CharacterController characterController, Brain brain)
    {
        CharacterController = characterController;
        Brain = brain;
    }
}

public class FoodSearchState : BehaviorState
{
    private readonly Brain _brain;
    private readonly CharacterController _controller;
    private readonly IInstantiator _instantiator;

    private Command _walkAroundCommand;
    
    public FoodSearchState(FoodSearchStateProtocol protocol, IInstantiator instantiator)
    {
        _brain = protocol.Brain;
        _controller = protocol.CharacterController;
        _instantiator = instantiator;
    }
    
    public override void OnEntry()
    {
        StateType = BehaviorStateType.Passive;
        DOVirtual.DelayedCall(0.001f, ()=>
        {
            FindFood();
        });
    }

    public void FindFood()
    {
        var foodList = _brain.GetInformationAboutEnviroment(EnviromentObjectType.Food); 
        if (foodList.Count != 0)
        {
            //иди к еде еблан
            _walkAroundCommand.Cancel();
            _controller.Walk(foodList[0].transform.position);
            _controller.Eat();
            FindFood();
        }
        else
        {
            //искать
            if (_walkAroundCommand == null)
            {
                _walkAroundCommand = _instantiator.Instantiate<WalkAroundCommand>(new[] {_controller});
                DOVirtual.DelayedCall(0.01f, () => { _walkAroundCommand.Do(); });
            }
            FindFood();
        }
    }

    public override void OnExit()
    {
        _walkAroundCommand.Cancel();        
    }
}
