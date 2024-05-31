using Godot;
using System;

public partial class shadow_character : CharacterBody2D
{
	public const float Speed = 200.0f;
	public const float JumpVelocity = -400.0f;
	private AnimatedSprite2D sprite2d;
	private CharacterBody2D mainCharacter;
	private Area2D collisionDetector;

	public override void _Ready()
    {
        sprite2d = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        GD.Print(sprite2d);

		mainCharacter = GetNode<CharacterBody2D>("%MainCharacter"); 	
		if (mainCharacter == null)
		{
			GD.PrintErr("Could not find main character");
		}

		collisionDetector = GetNode<Area2D>("CollisionDetector");
        collisionDetector.BodyEntered += OnBodyEntered;
    }

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		

		// Check the distance to mainCharacter
		if (mainCharacter != null)
		{
			float distance = DistanceToMainCharacter();
			double targetPosition = mainCharacter.GlobalPosition.X - 37.385147;
			
			
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
			{
				velocity.Y = JumpVelocity;
			}

			// Get the input direction and handle the movement/deceleration.
			// As good practice, you should replace UI actions with custom gameplay actions.
			if (distance > 40 || distance < 30)
			{
				Vector2 _target = new((float)targetPosition, mainCharacter.GlobalPosition.Y);
				Velocity = GlobalPosition.DirectionTo(_target) * 300.0f;

				// if (!mainCharacter.IsOnFloor())
				// {
				// 	GlobalPosition = new Vector2(GlobalPosition.X, mainCharacter.GlobalPosition.Y);
				// }		
				
				MoveAndSlide();
			} 
			else 
			{
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
			}
			
			bool isLeft = velocity.X < 0;
			sprite2d.FlipH = isLeft;
			
		}
	}

	public float DistanceToMainCharacter()
	{
		if (mainCharacter == null)
		{
			GD.PrintErr("Main character not assigned");
			return -1.0f;
		}

		return GlobalPosition.DistanceTo(mainCharacter.GlobalPosition);
	}

	private void OnBodyEntered(Node body)
    {
		GD.Print("Ajuns in fct on body entered");
        if (body is RigidBody2D)
        {
			float direction = Input.GetAxis("left", "right");
			//GD.Print("Collided with RigidBody2D: ", body.Name);
			if (Position.Y + 20 < mainCharacter.Position.Y) 
			{
				Position = new Vector2(Position.X, Position.Y + 3);
			}
			else
			{
				Position = new Vector2(Position.X + 1, Position.Y);
			}
        }
    }
}
