using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPartMessageType
{
    Damage,
    Hunger
}

public interface IBodyPart
{
    //public event EventHandler<BodyPartMessageType, object> SendMessageEvent;
}
