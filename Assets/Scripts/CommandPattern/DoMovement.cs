using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// User Input

public class DoMovement : MonoBehaviour
{
    public MoveTowardsPlayer _moveTowardsPlayer;
    public ChangeMovementInvoker _changeMovementInvoker;

    private void Start()
    {
        // Setup Invoker
        _changeMovementInvoker = new ChangeMovementInvoker();
    }

    void Update()
    {
        
        // If we press button -- Add Command to invoker list and execute the command
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ICommand toggleMoveCommand = new ToggleMoveTowardsPlayerCommand(_moveTowardsPlayer);
            _changeMovementInvoker.AddCommand(toggleMoveCommand);
        } else if (Input.GetKeyDown(KeyCode.C))
        {
            ICommand changeMovementCommand = new ChangeMovementCommand(_moveTowardsPlayer);
            _changeMovementInvoker.AddCommand(changeMovementCommand);
        } else if (Input.GetKeyDown(KeyCode.Z))
        {
            _changeMovementInvoker.UndoCommand();
        }
    }
}
