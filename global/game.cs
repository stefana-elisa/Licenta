using Godot;
using System;

public partial class game : Node
{
	public int PlayerSelect { get; set; } = 0;
    public int Level1Points { get; set; } = 0;
    public int Level2Points { get; set; } = 0;
    public int Level3Points { get; set; } = 0;
    public bool Level1Finished { get; set; } = false;
    public bool Level2Finished { get; set; } = false;
    public bool Level3Finished { get; set; } = false;

    public override void _Ready()
    {
        base._Ready();
        PlayerSelect = 0; 
    }
}
