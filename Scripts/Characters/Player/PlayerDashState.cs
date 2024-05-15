using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
[Export(PropertyHint.Range, "0, 20, .1")] private float speed = 15;
[Export] private Timer dashTimerNode;
    public override void _Ready()
    {
        base._Ready();
        dashTimerNode.Timeout += HandleDashTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        characterNode.MoveAndSlide();
        characterNode.Flip();
    }

    private void HandleDashTimeout()
    {
        characterNode.Velocity = Vector3.Zero;
        characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }

    protected override void EnterState()
    {
        base.EnterState();
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_DASH);
        characterNode.Velocity = new(characterNode.direction.X, 0, characterNode.direction.Y);
            if (characterNode.Velocity == Vector3.Zero)
            {
                characterNode.Velocity = characterNode.SpriteNode.FlipH ?
                    Vector3.Left :
                    Vector3.Right;

                // This is the more readable if statement representing the above ternary
                // if (characterNode.spriteNode.FlipH){
                // characterNode.Velocity = Vector3.Left;}
                // else {
                //characterNode.Velocity = Vector3.Right;}
            }
            characterNode.Velocity *= speed;
            dashTimerNode.Start();

    }
}

