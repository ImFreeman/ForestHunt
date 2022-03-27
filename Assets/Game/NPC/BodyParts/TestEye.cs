using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEye : BodyPart
{
    [SerializeField] private GameObject Food;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SignalEvent?.Invoke(this, new BodyPartSignal(BodyPartRole.EnviromentInformation, new []{GameObject.Find("Food")}));
        }
    }
}
