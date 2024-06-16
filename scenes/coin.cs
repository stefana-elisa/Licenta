using Godot;
using System;

public partial class coin : Area2D
{
    private game game;

    public override void _Ready()
    {
        game = GetNode<game>("/root/Game");
    }
    
    public void OnHeartBodyEntered(Node body){
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
            game.Level2Finished = true;
            CallDeferred(nameof(ChangeScene), "res://scenes/level3.tscn");
        }
        else if (sceneName == "level3" && body.Name == "ShadowCharacter")
        {
            game.Level3Finished = true;
            CallDeferred(nameof(ChangeScene), "res://scenes/end_screen.tscn");
        }
	}

    private void ChangeScene(string scenePath)
    {
        GetTree().ChangeSceneToFile(scenePath);
    }
}
