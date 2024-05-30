using Godot;
using System;

public partial class collectable : Area2D
{
	private game_manager gameManager;

    public override void _Ready()
    {
        gameManager = GetNode("%GameManager") as game_manager;
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
	}
}
