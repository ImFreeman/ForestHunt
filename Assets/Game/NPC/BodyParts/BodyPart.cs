using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum BodyPartSignalType
{
    EnviromentInformation,
    Container,
    Movement
}

public struct BodyPartSignal
{
    public BodyPartSignalType SignalType;
    public object[] Data;

    public BodyPartSignal(BodyPartSignalType signalType, object[] data)
    {
        SignalType = signalType;
        Data = data;
    }
}

public class BodyPart : MonoBehaviour, IBodyPart
{        
    public  EventHandler<BodyPartSignal> SignalEvent;
}
