using Godot;
using System;

public partial class main_character : CharacterBody2D
{
	public const float Speed = 200.0f;
	public const float JumpVelocity = -400.0f;
	float push_force = 80.0f;
	private AnimatedSprite2D sprite2d;

	public override void _Ready()
    {
        sprite2d = GetNode<AnimatedSprite2D>("Sprite2D");
        GD.Print(sprite2d);
    }

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (Math.Abs(velocity.X) > 1)
            sprite2d.Animation = "running";
        else
            sprite2d.Animation = "default";


		// Add the gravity.
		if (!IsOnFloor()) {
            velocity.Y += gravity * (float)delta;
            sprite2d.Animation = "jumping";
        }

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		float direction = Input.GetAxis("left", "right");
		if (direction != 0)
		{
			velocity.X = direction * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();

		//Pushing interactables
		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			var c = GetSlideCollision(i);
			if (c.GetCollider() is RigidBody2D)
			{
				((RigidBody2D)c.GetCollider()).ApplyCentralImpulse(-c.GetNormal() * push_force);
			}
		}

		bool isLeft = velocity.X < 0;
        sprite2d.FlipH = isLeft;
	}

	public override void _Input(InputEvent @event)
    {
        if ((@event is InputEventKey keyEvent) && Input.IsActionJustPressed("down") && IsOnFloor())
        {
            Position = new Vector2(Position.X, Position.Y + 1);
        }
    }
}
