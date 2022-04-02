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

    public EventHandler<BehaviorState> BrainEvent;

    private void Start()
    {
        brain.ChangeStateEvent += (object sender, BehaviorState e) => { BrainEvent?.Invoke(sender, e); };
    }

    public NavMeshAgent NavMeshAgent => navMeshAgent;

    public Vector2 Position
    {
        get => new Vector2(transform.position.x, transform.position.z);
        set => transform.position = value;
    }    
}
