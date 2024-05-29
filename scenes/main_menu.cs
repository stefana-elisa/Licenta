using Godot;
using System;

public partial class main_menu : Node
{
	private void _on_play_btn_pressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/character_select.tscn");
    }
}
