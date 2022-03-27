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

public class Brain : MonoBehaviour
{
    [SerializeField] private BodyPart[] _bodyParts;

    private GUID _id;
    private CharacterStorage _characterStorage;

    protected IInstantiator _instantiator;
    protected BehaviorStateMachine _stateMachine;
    protected CharacterController _controller;
    protected Dictionary<EnviromentObjectType, List<GameObject>> _enviromentInformation = new Dictionary<EnviromentObjectType, List<GameObject>>();
    protected List<NeedType> _needs = new List<NeedType>();

    public GUID ID
    {
        get => _id;
        set
        {
            _id = value;
            var character = _characterStorage.GetCharacter(value);
            _stateMachine = character.BehaviorStateMachine;
            _controller = character.Controller;
        }
    }         

    [Inject]
    public void Inject(CharacterStorage characterStorage, IInstantiator instantiator)
    {
        _instantiator = instantiator;
        _characterStorage = characterStorage;

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
        switch (signal.Role)
        {
            case BodyPartRole.EnviromentInformation:
                foreach (GameObject gameObject in signal.Data)
                {
                    AddEnviromentMemory(gameObject);
                }
                break;
            case BodyPartRole.Movement:
                // todo: Обрабатывать повреждение конечностей, использовать HealthHandler
                break;
            case BodyPartRole.Container:
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
            PassiveReaction();
        }
    }

    protected virtual void ActiveReaction(EnviromentObjectType type, GameObject gameObject)
    {
        
    }

    protected virtual void PassiveReaction()
    {
                
    }
}
