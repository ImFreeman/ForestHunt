using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

public enum EnviromentObjectType
{
    Danger,
    Food,    
    Friend,
    Unknown
}

public enum NeedType
{
    Hunger,
    Fatigue,
    Defecation
}

public class Brain : BodyPart
{
    [SerializeField] private BodyPart[] _bodyParts;         

    protected IInstantiator _instantiator;    
    protected Dictionary<EnviromentObjectType, List<GameObject>> _enviromentInformation = new Dictionary<EnviromentObjectType, List<GameObject>>();
    protected List<NeedType> _needs = new List<NeedType>();

    public EventHandler<IBehaviorState> ChangeStateEvent;             

    [Inject]
    public void Inject(CharacterStorage characterStorage, IInstantiator instantiator)
    {
        _instantiator = instantiator;        

        foreach (EnviromentObjectType key in Enum.GetValues(typeof(EnviromentObjectType)))
        {
            _enviromentInformation.Add(key, new List<GameObject>());
        }

        foreach (var bodyPart in _bodyParts)
        {
            bodyPart.SignalEvent+= SignalEventHandler;
        }
    }

    public List<GameObject> GetInformationAboutEnviroment(EnviromentObjectType key)
    {
        return _enviromentInformation[key];
    }

    private void SignalEventHandler(object sender, BodyPartSignal signal)
    {
        switch (signal.SignalType)
        {
            case BodyPartSignalType.EnviromentInformation:
                foreach (GameObject gameObject in signal.Data)
                {
                    AddEnviromentMemory(gameObject);
                }
                break;
            case BodyPartSignalType.Movement:
                // todo: Обрабатывать повреждение конечностей, использовать HealthHandler
                break;
            case BodyPartSignalType.Container:
                foreach (NeedType need in signal.Data)
                {
                    AddNeed(need);
                }
                break;
        }
    }

    private void AddEnviromentMemory(GameObject gObject)
    {
        var objectType = EnviromentObjectType.Unknown;
        switch (gObject.tag)
        {
            case "Food":
                objectType = EnviromentObjectType.Food;
                break;
            case "Enemy":
                objectType = EnviromentObjectType.Danger;
                break;
        }

        if (!_enviromentInformation[objectType].Contains(gObject))
        {
            _enviromentInformation[objectType].Add(gObject);
            ActiveReaction(objectType, gObject);
        }
    }

    private void AddNeed(NeedType need)
    {
        if (!_needs.Contains(need))
        {
            _needs.Add(need);
            PassiveReaction(need);
        }
    }

    protected virtual void ActiveReaction(EnviromentObjectType type, GameObject gameObject)
    {
        Debug.Log("There no active reaction!");
    }

    protected virtual void PassiveReaction(NeedType need)
    {
        Debug.Log("There no passive reaction!");        
    }
}
