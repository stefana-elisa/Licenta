using Godot;
using System;

public partial class game : Node
{
	public int PlayerSelect { get; set; } = 0;
    public int Level1Points { get; set; } = 0;
    public int Level2Points { get; set; } = 0;

    public override void _Ready()
    {
        base._Ready();
        PlayerSelect = 0; 
    }
}
