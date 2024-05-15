using Godot;
using System;

public partial class EnemyIdleState : EnemyState
{

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }
    protected override void EnterState()
    {
        base.EnterState();
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_IDLE);
        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        base.ExitState();
        characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }

}
