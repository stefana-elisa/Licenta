using Godot;
using System;

public partial class game_manager : Node
{
	private int points = 0;

    public void AddPoints()
    {
        points += 1;
        GD.Print(points);
    }
}
