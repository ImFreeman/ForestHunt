using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPartRole
{
    EnviromentInformation,
    Container,
    Movement
}

public struct BodyPartSignal
{
    public BodyPartRole Role;
    public object[] Data;

    public BodyPartSignal(BodyPartRole role, object[] data)
    {
        Role = role;
        Data = data;
    }
}

public class BodyPart : MonoBehaviour, IBodyPart
{
    [SerializeField] private BodyPartRole[] roles;

    public BodyPartRole[] Roles => roles;

    public  EventHandler<BodyPartSignal> SignalEvent;
}
