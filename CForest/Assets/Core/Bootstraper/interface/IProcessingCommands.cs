using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProcessingCommands
{
    event EventHandler AllCommandsDone;

    bool IsExecuting { get; }

    void AddCommand(ICommand cmd);
    void StartExecute();
    void Clear();

    bool Any();
}
