using Godot;
using System;
using System.Linq;

public partial class EnemyChaseState : EnemyState
{

    
    [Export(PropertyHint.Range, "0, 1, .01")] Timer chaseTimer;
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_MOVE);
        target = characterNode.ChaseAreaNode.GetOverlappingBodies().First() as CharacterBody3D;
        chaseTimer.Timeout += HandleTargetLocationUpdate;
        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
        characterNode.AttackAreaNode.BodyEntered += HandleAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited += HandleChaseAreaBodyExited;

    }




    protected override void ExitState()
    {
        chaseTimer.Timeout -= HandleTargetLocationUpdate;
        characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
        characterNode.AttackAreaNode.BodyEntered -= HandleAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited -= HandleChaseAreaBodyExited;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }
        private void HandleTargetLocationUpdate()
    {
        destination = target.GlobalPosition;
        characterNode.AgentNode.TargetPosition = destination;
        chaseTimer.Start();
    }

    private void HandleAttackAreaBodyEntered(Node3D body)
     {
            characterNode.StateMachineNode.SwitchState<EnemyAttackState>();
     }

    private void HandleChaseAreaBodyExited(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }
}
