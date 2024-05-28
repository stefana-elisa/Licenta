using Godot;
using System;

public partial class crate : RigidBody2D
{
	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		AngularVelocity = 0;
		Rotation = 0;
	}
}
