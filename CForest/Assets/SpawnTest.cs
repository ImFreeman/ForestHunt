using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnTest : MonoBehaviour
{
    private CharacterStorage _characterStorage;

    [Inject]
    public void Inject(CharacterStorage characterStorage)
    {
        _characterStorage = characterStorage;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _characterStorage.Spawn(new CharacterSpawnProtocol(new Vector3(0, 2.636933f, 0), "Deer"));
        }
    }
}
