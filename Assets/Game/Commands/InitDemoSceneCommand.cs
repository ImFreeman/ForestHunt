using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class InitDemoSceneCommand : Command
{
    private readonly EnviromentStorage _enviromentStorage;
    
    public InitDemoSceneCommand(EnviromentStorage enviromentStorage)
    {
        _enviromentStorage = enviromentStorage;
    }
    
    public override CommandResult Do()
    {        
        var res = base.Do();

        _enviromentStorage.Spawn<DemoSceneView>("DemoScene");
        
        Done?.Invoke(this,EventArgs.Empty);
        
        return res;
    }
}
