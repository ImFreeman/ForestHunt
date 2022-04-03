using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    [SerializeField] private Brain brain;

    public EventHandler<IBehaviorState> BrainEvent;

    private void Start()
    {
        brain.ChangeStateEvent += (object sender, IBehaviorState e) => { BrainEvent?.Invoke(sender, e); };
    }

    public NavMeshAgent NavMeshAgent => navMeshAgent;

    public Vector3 Position
    {        
        get => transform.position;
        set => transform.position = value;
    }    
}
