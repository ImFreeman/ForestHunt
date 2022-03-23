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
    
    private GUID _id;

    public GUID ID
    {
        get => _id;
        set 
        {
            _id = value;
            brain.ID = value;
        }
    }

    public NavMeshAgent NavMeshAgent => navMeshAgent;

    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }
}
