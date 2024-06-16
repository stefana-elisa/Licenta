using Godot;
using System;

public partial class shadow_character : CharacterBody2D
{
	public const float Speed = 200.0f;
	public const float JumpVelocity = -400.0f;
	private AnimatedSprite2D sprite2d;
	private CharacterBody2D mainCharacter;
	private Area2D collisionDetector;
	public bool climbing = false;

	public override void _Ready()
    {
        sprite2d = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        //GD.Print(sprite2d);

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

	        if (mainCharacter is main_character main)
			{
				if (main.climbing == false)
				{
					// Add the gravity.
					if (!IsOnFloor()) {
						velocity.Y += gravity * (float)delta;
						sprite2d.Animation = "jumping";
					}
				}
				else if (main.climbing == true)
				{
							velocity.Y = 0;
					if (Input.IsActionPressed("jump"))
					{
						velocity.Y = -600 * (float)delta * 10;
						sprite2d.Animation = "jumping";
					}
					else if (Input.IsActionPressed("down"))
					{
						velocity.Y = 600 * (float)delta * 10;
						sprite2d.Animation = "jumping";
					}
				}
			}
			

			// Handle Jump.
			if (Input.IsActionJustPressed("jump") && IsOnFloor())
			{
				velocity.Y = JumpVelocity;
			}

			if (distance > 40) //GlobalPosition.X + 37 < mainCharacter.GlobalPosition.X)
			{
				Vector2 _target = new((float)targetPosition, mainCharacter.GlobalPosition.Y);
				Velocity = GlobalPosition.DirectionTo(_target) * 600.0f;
	
				
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
			}
			MoveAndSlide();

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
		//GD.Print("Ajuns in fct on body entered");
        if (body is RigidBody2D)
        {
			float direction = Input.GetAxis("left", "right");
			if (Position.Y + 20 < mainCharacter.Position.Y) 
			{
				//GD.Print(Position);
				Position = new Vector2(Position.X, Position.Y + 3);
				//GD.Print("function 1");
				//GD.Print(Position);
			}
			else
			{
				Position = new Vector2(Position.X + 1, Position.Y);
			}
        }
    }

	public override void _Input(InputEvent @event)
    {
        if ((@event is InputEventKey keyEvent) && Input.IsActionJustPressed("down") && IsOnFloor() && Position.Y + 20 >= mainCharacter.Position.Y)
        {
            Position = new Vector2(Position.X, Position.Y + 1);
			
        }
    }
}
