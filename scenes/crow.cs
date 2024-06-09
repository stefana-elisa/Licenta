using Godot;
using System;

public partial class crow : CharacterBody2D
{
	public const float Speed = 300.0f;

	public Vector2 original_position;
	public Vector2 target_position;
	private AnimatedSprite2D sprite2d;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _Ready()
    {
		original_position = new Vector2(Position.X, Position.Y);
        target_position = new Vector2(Position.X - 200, Position.Y);
		sprite2d = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		if (Position == original_position)
		{
			Velocity = Position.DirectionTo(target_position) * Speed;
		}
		else if (Position == target_position)
		{
			Velocity = Position.DirectionTo(original_position) * Speed;
		}

		bool isLeft = velocity.X < 0;
        sprite2d.FlipH = isLeft;

		MoveAndSlide();
	}

	private void _on_collision_detector_body_entered(Node body)
	{
		var currentScene = GetTree().CurrentScene;

        if (currentScene == null)
        {
            GD.PrintErr("No current scene found");
            return;
        }

        string sceneName = currentScene.Name;

        if (sceneName == "level1" && body.Name == "MainCharacter")
        {
            CallDeferred(nameof(ChangeScene), "res://scenes/level2.tscn");
        }
        else if (sceneName == "level2" && body.Name == "ShadowCharacter")
        {
            CallDeferred(nameof(ChangeScene), "res://scenes/end_screen.tscn");
        }
	}

	private void ChangeScene(string scenePath)
    {
        GetTree().ChangeSceneToFile(scenePath);
    }
}
