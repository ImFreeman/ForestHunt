using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class AplicationInstaller : MonoInstaller
{    
    public override void InstallBindings()
    {
        // boot launcher
        BootstrapInstaller.Install(Container);

        //Enviroment        
        Container
            .Bind<EnviromentStorage>()
            .AsSingle();
        
        //Characters
        CharacterInstaller.Install(Container);
        
        //app launch
        Container
            .Bind<ApplicationLauncher>()
            .AsSingle()
            .NonLazy();
    }
}
