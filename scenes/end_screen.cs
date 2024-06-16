using Godot;
using System;

public partial class end_screen : Node
{
	private game game;
	private Label scoreLabel;

	 public override void _Ready()
    {
		scoreLabel = GetNode<Label>("%ScoreLabel");
		game = GetNode<game>("/root/Game");
    
		//GD.Print(game.Level1Points);
		//GD.Print(game.Level2Points);

		float score = (float)(game.Level1Points + game.Level2Points + game.Level3Points) / 15 * 100;
		int roundedScore = (int)Math.Round(score);
		scoreLabel.Text = "Your score is: " + roundedScore + "%";
		//GD.Print("Your score is: " + score + "%");
	}

	private void _on_go_back_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/main_menu.tscn");
	}
}
