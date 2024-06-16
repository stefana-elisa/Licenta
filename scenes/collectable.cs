using Godot;
using System;

public partial class collectable : Area2D
{
	private game_manager gameManager;
	private AnimatedSprite2D sprite2d;

    public override void _Ready()
    {
        gameManager = GetNode("%GameManager") as game_manager;
		sprite2d = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _Process(double delta)
    {
        var currentScene = GetTree().CurrentScene;

        if (currentScene == null)
        {
            GD.PrintErr("No current scene found");
            return;
        }

        string sceneName = currentScene.Name;

		if (sceneName == "level1")
		{
			sprite2d.Animation = "yarn";
		} else if (sceneName == "level2")
		{
			sprite2d.Animation = "feather";
		} else if (sceneName == "level3")
		{
			sprite2d.Animation = "feather";
		}
    }


    public void OnBodyEntered(Node body){
		var currentScene = GetTree().CurrentScene;

        if (currentScene == null)
        {
            GD.PrintErr("No current scene found");
            return;
        }

        string sceneName = currentScene.Name;

		if (sceneName == "level1" && body.Name == "MainCharacter")
		{
			QueueFree();
			gameManager.AddPoints();
		}
		else if (sceneName == "level2" && body.Name == "ShadowCharacter")
		{
			QueueFree();
			gameManager.AddPoints();
		}
		else if (sceneName == "level3" && body.Name == "ShadowCharacter")
		{
			QueueFree();
			gameManager.AddPoints();
		}
	}
}
