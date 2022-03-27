using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class WalkAroundCommand : Command
{
    private CharacterController _characterController;
    private Random _random = new Random();
    private List<Vector2> _oldPoints = new List<Vector2>(); 
    
    public WalkAroundCommand(CharacterController characterController)
    {
        _characterController = characterController;
    }
    
    public override CommandResult Do()
    {
        var rez = base.Do();        
        
        WalkAround();
        
        return rez;
    }

    private void WalkAround()
    {
        var point = new Vector2(_random.Next(-5,5), _random.Next(-5,5));

        _characterController.Walk(point);
        WalkAround();
    }

    public override void Cancel()
    {
        Done?.Invoke(this, EventArgs.Empty);
        Dispose();
    }        
}
