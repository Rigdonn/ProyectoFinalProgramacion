using Godot;
using System;

public partial class Audio : TabBar
{
	// Esta clase controla el audio del juego desde la pestaña sonido en opciones
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	private void _on_master_value_changed(double value)
	{
		set_volume(0, value);
	}
	private void _on_music_value_changed(double value)
	{
		set_volume(1, value);
	}
	private void _on_sfx_value_changed(double value)
	{
		set_volume(2, value);
	}

	private void set_volume(int idx, double value)
	{
		AudioServer.SetBusVolumeDb(idx, Mathf.LinearToDb((float)value));
	}
}
