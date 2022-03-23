using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public interface IBootstrap
{
    event EventHandler<float> ProgressUpdate;

    void StartExecute();
    void AddCommand(ICommand cmd);
}
