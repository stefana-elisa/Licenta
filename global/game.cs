using Godot;
using System;

public partial class game : Node
{
	public int PlayerSelect { get; set; } = 0;

    public override void _Ready()
    {
        base._Ready();
        // Initialize PlayerSelect or any other setup if needed
        PlayerSelect = 0;  // This is already initialized by the property setter
    }
}
