using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class CharacterView : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }
}
