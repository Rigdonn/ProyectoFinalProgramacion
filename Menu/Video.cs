using Godot;
using System;

public partial class Video : TabBar
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	private void _on_full_screen_toggled(bool toggled_on) //FullScreen
	{
		if (toggled_on)
		{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
		}
		else
		{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
		}
	}
	private void _on_borderless_toggled(bool toggled_on) //Modo sin bordes
	{
		DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, toggled_on);
		
	}

	private void _on_exit_to_menu_pressed() //para salir del menú
	{
		GetTree().ChangeSceneToFile("res://Menu/main_menu.tscn");
	}
}
