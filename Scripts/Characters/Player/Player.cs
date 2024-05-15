using Godot;
using System;

public partial class Player : Character
{

    public override void _Input(InputEvent @event)
    {
       direction = Input.GetVector(GameConstants.MOVE_LEFT, GameConstants.MOVE_RIGHT, 
       GameConstants.MOVE_UP, GameConstants.MOVE_DOWN);

    }

}
