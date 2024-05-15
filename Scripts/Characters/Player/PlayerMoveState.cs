using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{
    [Export(PropertyHint.Range, ".01,20,.01")] private float moveSpeed = 5;
     public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction == Vector2.Zero)
        {
            characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
            return;
        }
        characterNode.Velocity = new(characterNode.direction.X, 0, characterNode.direction.Y);
        characterNode.Velocity *= moveSpeed;
        characterNode.MoveAndSlide();
        characterNode.Flip();
    }

    public override void _Input(InputEvent @event)
    {
        CheckForAttackInput();
        
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            characterNode.StateMachineNode.SwitchState<PlayerDashState>();
        }
    }
    protected override void EnterState()
    {
        base.EnterState();
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_MOVE);
    }
}
