// Concrete Command

public class ToggleMoveTowardsPlayerCommand : ICommand
{
    MoveTowardsPlayer _moveTowardsPlayer;
    
    public ToggleMoveTowardsPlayerCommand(MoveTowardsPlayer moveTowardsPlayer) // Self-named function for command class
    {
        _moveTowardsPlayer = moveTowardsPlayer;
    }
    
    public void Execute()
    {
        _moveTowardsPlayer.ToggleMoveTowardsTarget();
    }

    public void Undo()
    {
        _moveTowardsPlayer.ToggleMoveTowardsTarget();
    }
}
