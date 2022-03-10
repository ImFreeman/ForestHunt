using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public struct AnimalViewProtocol
{
    public Vector3 Position;

    public AnimalViewProtocol(Vector3 position)
    {
        Position = position;
    }
}

public class AnimalView : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    
    public class AnimalViewFactory : PlaceholderFactory<AnimalViewProtocol, AnimalViewFactory>
    {
        
    }

}
