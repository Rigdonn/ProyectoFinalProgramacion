using Godot;
using System;

public partial class ObjetoQueCae : Area2D
{
	// Called when the node enters the scene tree for the first time.
	private Vector2 velocidad;
	public override void _Ready()
	{
		Position = new Vector2(GD.Randi() % 1000, -20);
		velocidad = new Vector2(0, 150);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += velocidad * (float)delta;
		
	}
}
