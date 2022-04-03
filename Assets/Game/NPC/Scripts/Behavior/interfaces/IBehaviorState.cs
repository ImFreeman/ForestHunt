using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public interface IBehaviorState
{
    GUID ID { get; set; }
    void OnEntry();
    void OnExit();
}
