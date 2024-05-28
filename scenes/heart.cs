using Godot;
using System;

public partial class heart : Area2D
{
	public void OnHeartBodyEntered(Node body){
		if (body.Name == "CharacterBody2D")
        {
            GetTree().ChangeSceneToFile("res://scenes/level2.tscn");
        }
	}
}
