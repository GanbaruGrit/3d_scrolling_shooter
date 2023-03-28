using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores list of commands over time

public class ChangeMovementInvoker
{
    Stack<ICommand> _commandList;

    public ChangeMovementInvoker() // Invoker has function named after class
    {
        _commandList = new Stack<ICommand>();
    }

    public void AddCommand(ICommand newCommand)
    {
        newCommand.Execute();
        _commandList.Push(newCommand);
    }

    public void UndoCommand()
    {
        if (_commandList.Count > 0)
        {
            ICommand latestCommand = _commandList.Pop();
            latestCommand.Undo();
        }
    }
}

