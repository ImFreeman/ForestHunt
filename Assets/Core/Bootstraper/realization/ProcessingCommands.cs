using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessingCommands : IProcessingCommands
{
    public event EventHandler AllCommandsDone;
    public bool IsExecuting { get; protected set; }
    public Queue<ICommand> Queue => _queue;
        
    private readonly Queue<ICommand> _queue = new Queue<ICommand>();

    protected int Count => _queue.Count;

    public void AddCommand(ICommand cmd)
    {
        if (cmd == null)
        {
            Debug.LogError("Command is null");
            return;
        }
            
        _queue.Enqueue(cmd);
    }

    public void Clear()
    {
        _queue.Clear();
    }

    public bool Any()
    {
        return _queue.Count > 0;
    }

    public virtual void StartExecute() { Execute(); }

    protected virtual void Execute() { }

    protected ICommand Dequeue()
    {
        return _queue.Count > 0 ? _queue.Dequeue() : null;
    }

    protected void OnComplete()
    {
        AllCommandsDone?.Invoke(this, EventArgs.Empty);
    }
}
