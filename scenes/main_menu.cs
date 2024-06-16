using Godot;
using System;

public partial class main_menu : Node
{
	private void _on_play_btn_pressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/levels_menu.tscn");
    }
    private void _on_options_btn_pressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/character_select.tscn");
    }
    private void _on_quit_btn_pressed()
    {
        GetTree().Quit();
    }
}
