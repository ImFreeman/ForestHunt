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
            Food = GameObject.Find("Food");
            SignalEvent?.Invoke(this, new BodyPartSignal(BodyPartRole.EnviromentInformation, new []{Food}));
        }
    }
}
