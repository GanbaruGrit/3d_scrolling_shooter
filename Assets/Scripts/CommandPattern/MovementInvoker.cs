using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInvoker
{
    ICommand _onCommand;

    public MovementInvoker(ICommand onCommand) // Invoker has function named after class
    {
        _onCommand = onCommand;
    }

    public void ToggleRunInvoke()
    {
        _onCommand.Execute();
    }
}
