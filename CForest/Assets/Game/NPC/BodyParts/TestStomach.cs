using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStomach : BodyPart
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SignalEvent?.Invoke(this, new BodyPartSignal(BodyPartRole.Container, new [] {NeedType.Hunger as object}));
        }
    }
}
