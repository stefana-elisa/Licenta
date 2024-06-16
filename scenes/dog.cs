using Godot;
using System;

public partial class dog : CharacterBody2D
{
	public float Speed = 150.0f;
	bool facing_right = true;
	private AnimatedSprite2D sprite2d;
	private RayCast2D raycast2d;
	private Area2D collisionDetector;

    public override void _Ready()
    {
        sprite2d = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		if (sprite2d == null)
		{
			GD.PrintErr("Could not find sprite");
		}
		raycast2d = GetNode<RayCast2D>("RayCast2D");
		if (raycast2d == null)
		{
			GD.PrintErr("Could not find raycast");
		}

		collisionDetector = GetNode<Area2D>("CollisionDetector");
        collisionDetector.BodyEntered += OnBodyEntered;
	}

	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
		}

		if (raycast2d.IsColliding())
		{
			flip();

			Vector2 targetPosition  = raycast2d.TargetPosition;
            targetPosition.X *= -1;
            raycast2d.TargetPosition = targetPosition ;
		}

		velocity.X = Speed;
		Velocity = velocity;
		MoveAndSlide();
	}

	public void flip()
    {
		facing_right = !facing_right;
		sprite2d.FlipH = !facing_right;
    
		if (facing_right == true)
		{
			Speed = Mathf.Abs(Speed);
		}
		else
		{
			Speed = Mathf.Abs(Speed) * -1;
		}
	}

	private void OnBodyEntered(Node body)
    {
		//GD.Print("Ajuns in fct on body entered");
        if (body.Name == "MainCharacter")
        {
			CallDeferred(nameof(ChangeScene), "res://scenes/end_screen.tscn");
		}
	}

	private void ChangeScene(string scenePath)
    {
        GetTree().ChangeSceneToFile(scenePath);
    }
}
