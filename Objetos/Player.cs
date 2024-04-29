using Godot;
using System;
using System.Threading;
//shift+alt+f auto-format prettier
public partial class Player : Area2D 
{
	// Called when the node enters the scene tree for the first time. Inicializar variables
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame. //En cada fotograma del juego
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("ui_right"))
		{
			Position += new Vector2((float)(200 * delta), 0);
			 //el cast a float porque porque delta es un doble, delta(frame rate)
		}
		else if (Input.IsActionPressed("ui_left"))
		{
			Position += new Vector2((float)(-200 * delta), 0);
		}
		else if (Input.IsActionPressed("ui_up"))
		{
			Position += new Vector2(0, (float)(-200 * delta));
		}
		else if (Input.IsActionPressed("ui_down"))
		{
			Position += new Vector2(0, (float)(200 * delta));
		}
		
		
	}
	
}
