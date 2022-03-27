using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BootstrapInstaller : Installer<BootstrapInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IBootstrap>().To<Bootstrap>().AsSingle();
    }
}
