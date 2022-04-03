using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnTest : MonoBehaviour
{
    private CharacterStorage _characterStorage;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int radius = 10;
    [SerializeField] private bool IsOn = false;

    [Inject]
    public void Inject(CharacterStorage characterStorage)
    {
        _characterStorage = characterStorage;
    }
    
    void Update()
    {
        if (IsOn)
        {
            for (int i = 0; i < 100; i++)
            {
                var obj = Instantiate(prefab);
                obj.transform.position = Random.insideUnitSphere * radius + transform.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _characterStorage.Spawn(new CharacterSpawnProtocol(new Vector3(0, 2.636933f, 0), "Deer"));
        }
    }
}
