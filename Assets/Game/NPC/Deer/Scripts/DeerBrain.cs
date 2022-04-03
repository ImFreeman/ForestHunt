using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerBrain : Brain
{
    protected override void ActiveReaction(EnviromentObjectType type, GameObject gameObject)
    {
        
    }

    protected override void PassiveReaction(NeedType need)
    {
        switch (need)
        {
            case NeedType.Hunger:
                var state = _instantiator.Instantiate<FoodSearchState>(new []{this});
                ChangeStateEvent?.Invoke(this, state);
                break;
            case NeedType.Fatigue:
                break;
            case NeedType.Defecation:
                break;
        }                        
    }        
}
