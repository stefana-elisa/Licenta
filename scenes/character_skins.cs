using Godot;
using System;
using System.Collections.Generic;

public partial class character_skins : AnimatedSprite2D
{
	private game game;
	Dictionary<int, Func<Resource>> players = new Dictionary<int, Func<Resource>>()
	{
		{ 0, () => GD.Load<Resource>("resources/sprite_frames/white_cat.tres") },
		{ 1, () => GD.Load<Resource>("resources/sprite_frames/black_cat.tres") },
		{ 2, () => GD.Load<Resource>("resources/sprite_frames/calico_cat.tres") }
	};

	public override void _Ready()
    {
		// game = GetNode<game>("global/game.cs");

		// if (game == null)
        // {
        //     GD.PrintErr("Game object is not initialized");
        //     return;
        // }

		game = GetNode<game>("/root/Game");

        if (players.TryGetValue(game.PlayerSelect, out var loadResource))
        {
            var resource = loadResource();
            if (resource is SpriteFrames spriteFrames)
            {
                SpriteFrames = spriteFrames;
            }
            else
            {
                GD.PrintErr("Loaded resource is not of type SpriteFrames");
            }
        }
        else
        {
            GD.PrintErr($"No resource found for player selection: {game.PlayerSelect}");
        }
    }
}
