using Godot;
using System;

public partial class death_screen : Node
{
	private void _on_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/main_menu.tscn");
	}
}
