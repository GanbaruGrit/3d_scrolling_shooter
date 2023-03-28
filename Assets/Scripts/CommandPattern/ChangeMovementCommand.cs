using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMovementCommand : ICommand
{
    // Stored lightbulb receiver
    MoveTowardsPlayer _moveTowardsPlayer;

    // Stored previous random movement
    public float _previousMovement;

    public ChangeMovementCommand(MoveTowardsPlayer moveTowardsPlayer) // Self-named function for command class
    {
        _moveTowardsPlayer = moveTowardsPlayer;
        _previousMovement = moveTowardsPlayer.randomNum;
    }

    public void Execute()
    {
        _moveTowardsPlayer.SetRandomMovement();
    }

    public void Undo()
    {
        _moveTowardsPlayer.SetSpecificMovement(_previousMovement);
    }
}
