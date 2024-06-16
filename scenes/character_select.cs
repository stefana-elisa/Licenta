using Godot;
using System;

public partial class character_select : Node
{
	private game game;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		game = GetNode<game>("/root/Game");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		switch (game.PlayerSelect)
        {
            case 0:
                GetNode<AnimatedSprite2D>("%PlayerSelect").Play("player0");
                break;
            case 1:
				GetNode<AnimatedSprite2D>("%PlayerSelect").Play("player1");
				break;
			case 2:
				GetNode<AnimatedSprite2D>("%PlayerSelect").Play("player2");
				break;
        }
	}

	public void _on_right_pressed()
	{
		if (game.PlayerSelect < 2)
		{
			game.PlayerSelect += 1;
		}
		else if (game.PlayerSelect == 2)
		{
			game.PlayerSelect = 0;
		}
	}

	public void _on_left_pressed()
	{
		if (game.PlayerSelect > 0)
		{
			game.PlayerSelect -= 1;
		}
		else if (game.PlayerSelect == 0)
		{
			game.PlayerSelect = 2;
		}
	}

	public void _on_select_pressed()
	{
		//GetTree().ChangeSceneToFile("res://scenes/levels_menu.tscn");
	}

	public void _on_back_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/main_menu.tscn");
	}
}
