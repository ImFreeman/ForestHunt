using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CommandStatus
{
    Success,
    InProgress,
    Failed
}

public class CommandResult
{
    public object Body;
    public CommandStatus CommandStatus=CommandStatus.Success;        
}

public class Command : ICommand, IDisposable
{
    public EventHandler Done { get; set; }
        
    public virtual CommandResult Do()
    {
        return new CommandResult();
    }

    public Command()
    {        
        Done += OnDone;
    }
        
    protected virtual void OnDone(object sender, EventArgs e)
    {
        
    }

    public virtual void Cancel()
    {
            
    }
        
    public void Dispose()
    {
            
    }
}
