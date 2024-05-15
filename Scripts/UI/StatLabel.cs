using Godot;
using System;
using System.ComponentModel;

public partial class StatLabel : Label
{
    [Export] private StatResource statResource;

    public override void _Ready()
    {
        statResource.OnUpdate += HandleStatUpdate;

        Text = statResource.StatValue.ToString();
    }

    private void HandleStatUpdate()
    {
        Text = statResource.StatValue.ToString();
    }
}
