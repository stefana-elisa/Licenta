using Godot;
using System;

public partial class game_manager : Node
{
	private game game;
	private int points = 0;
	private Label pointsLabel;

    public override void _Ready()
    {
        pointsLabel = GetNode<Label>("%PointsLabel");
		game = GetNode<game>("/root/Game");
    }

    public void AddPoints()
    {
		var currentScene = GetTree().CurrentScene;

		if (currentScene == null)
        {
            GD.PrintErr("No current scene found");
            return;
        }

        string sceneName = currentScene.Name;

        points += 1;

		if (sceneName == "level1")
		{
			pointsLabel.Text = "Points: " + points + " / 5";
			game.Level1Points +=1;
		} else if (sceneName == "level2")
		{
			pointsLabel.Text = "Points: " + points + " / 5";
			game.Level2Points +=1;
		} else if (sceneName == "level3")
		{
			pointsLabel.Text = "Points: " + points + " / 5";
			game.Level3Points +=1;
		}

    }
}
