using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ApplicationLauncher
{
    public ApplicationLauncher(IBootstrap bootstrap, IInstantiator instantiator)
    {                            
        bootstrap.AddCommand(instantiator.Instantiate<InitDemoSceneCommand>());        
            
        bootstrap.StartExecute();
    }
}
