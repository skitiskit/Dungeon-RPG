using Godot;
using System;

public partial class DeathState : EnemyState
{
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_DEATH);
        characterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    private void  HandleAnimationFinished(StringName animName)
    {
        characterNode.PathNode.QueueFree();
    }

}
