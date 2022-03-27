using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnviromentInstaller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private EnviromentStorage _enviromentStorage;
    
    [Inject]
    public void Inject(EnviromentStorage enviromentStorage)
    {
        _enviromentStorage = enviromentStorage;
    }
}
