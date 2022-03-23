using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerBrain : Brain
{
    protected override void ActiveReaction(EnviromentObjectType type, GameObject gameObject)
    {
        
    }

    protected override void PassiveReaction()
    {
        var state = _instantiator.Instantiate<FoodSearchState>(new []{new FoodSearchStateProtocol(_controller, this)});
        _stateMachine.ChangeState(state);
    }
}
