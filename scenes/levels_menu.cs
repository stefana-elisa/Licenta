using Godot;
using System;

public partial class levels_menu : Node
{
	private game game;
	private Button level1;
	private Button level2;
	private Button level3;

	public override void _Ready()
	{
		game = GetNode<game>("/root/Game");
		level1 = GetNode<Button>("Panel/level1");
		level2 = GetNode<Button>("Panel/level2");
		level3 = GetNode<Button>("Panel/level3");

		level1.Disabled = false;
		level2.Disabled = true;
		level3.Disabled = true;
	}

	public override void _Process(double delta)
	{
		if (game.Level1Finished == true)
		{
			level2.Disabled = false;
		}

		if (game.Level2Finished == true)
		{
			level3.Disabled = false;
		}
	}

	public void _on_level_1_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/level1.tscn");
	}

	public void _on_level_2_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/level2.tscn");
	}

	public void _on_level_3_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/level3.tscn");
	}

	public void _on_back_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/main_menu.tscn");
	}
}
