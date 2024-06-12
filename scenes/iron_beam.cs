using Godot;
using System;

public partial class iron_beam : RigidBody2D
{
	private Area2D collisionDetector;
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public override void _Ready()
	{
		Freeze = true;

		collisionDetector = GetNode<Area2D>("CollisionDetector");
        collisionDetector.BodyEntered += OnBodyEntered;
	}
	
	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		AngularVelocity = 0;
		Rotation = 0;
	}

	private void OnBodyEntered(Node body)
    {
		GD.Print("Ajuns in fct on body entered");
        if (body.Name == "MainCharacter")
        {
			CallDeferred(nameof(Unfreeze));
        }
    }

	private void Unfreeze()
	{
		Freeze = false;
	}
}
