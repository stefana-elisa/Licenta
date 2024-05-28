using Godot;
using System;

public partial class collectable : Area2D
{
	public void OnBodyEntered(Node body){
		if (body.Name == "CharacterBody2D")
		{
			QueueFree();
		}
	}
}
