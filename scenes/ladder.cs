using Godot;
using System;

public partial class ladder : Area2D
{
    private void _on_ladder_body_entered(Node body)
	{
		if (body is main_character mainCharacter)
		{
			if (mainCharacter.climbing == false)
			{
				mainCharacter.climbing = true;
			}
		}
	}

	private void _on_ladder_body_exited(Node body)
	{
		if (body is main_character mainCharacter)
		{
			if (mainCharacter.climbing == true)
			{
				mainCharacter.climbing = false;
			}
		}
	}
}
