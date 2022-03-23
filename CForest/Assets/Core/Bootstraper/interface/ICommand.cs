using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    EventHandler Done { get; set; }
    CommandResult Do();
    void Cancel();
}
