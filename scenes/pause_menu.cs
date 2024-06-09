using Godot;
using System;

public partial class pause_menu : Control
{
	private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _animationPlayer.Play("RESET");
    }

    public void Resume()
    {
        GetTree().Paused = false;
        _animationPlayer.PlayBackwards("blur");
    }

    public void Pause()
    {
        GetTree().Paused = true;
        _animationPlayer.Play("blur");
    }

    public void TestEsc()
    {
        if (Input.IsActionJustPressed("esc") && !GetTree().Paused)
        {
            Pause();
        }
        else if (Input.IsActionJustPressed("esc") && GetTree().Paused)
        {
            Resume();
        }
    }

    public void _on_resume_pressed()
    {
        Resume();
    }

    public void _on_restart_pressed()
    {
        Resume();
        GetTree().ReloadCurrentScene();
    }
  
    public void _on_quit_pressed()
    {
        Resume();
        GetTree().ChangeSceneToFile("res://scenes/main_menu.tscn");
    }

    public override void _Process(double delta)
    {
        TestEsc();
    }
}
