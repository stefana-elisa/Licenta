using Godot;
using System;

public partial class heart : Area2D
{
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
            CallDeferred(nameof(ChangeScene), "res://scenes/main_menu.tscn");
        }
	}

    private void ChangeScene(string scenePath)
    {
        GetTree().ChangeSceneToFile(scenePath);
    }
}
