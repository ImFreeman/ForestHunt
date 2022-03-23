using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterInstaller : Installer<CharacterInstaller>
{    
    public override void InstallBindings()
    {
        Container
            .BindFactory<CharacterControllerProtocol, CharacterController, CharacterController.Factory>()
            .AsSingle();
        
        Container
            .BindFactory<BehaviorStateMachine, BehaviorStateMachine.Factory>()
            .AsSingle();
        
        Container
            .Bind<CharacterStorage>()
            .AsSingle();                
    }
}
