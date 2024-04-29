using Godot;
using System;
using System.Numerics;
using System.Threading;
using Vector2 = Godot.Vector2;

public partial class escena_juego : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private int puntos = 0;
	private Player player;
	private PackedScene objeto;
	private PackedScene mainMenu;
	public override void _Ready()
	{
		mainMenu = GD.Load<PackedScene>("res://main_menu.tscn");
		player = GetNode<Player>("/root/EscenaJuego/Player");
		//objeto = GD.Load<PackedScene>("res://objeto_que_cae.tscn");
		GD.Randomize();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
public override void _Process(double delta)
{
	
	if (Input.IsKeyPressed(Godot.Key.Space))
	{
		GD.Print("Cayendo");
		var objetoCae = objeto.Instantiate();
		AddChild(objetoCae);
	}
	if(Input.IsKeyPressed(Godot.Key.Escape)){
		if(GetTree().Paused == false){
			GetTree().ChangeSceneToFile("res://escena_juego.tscn");
			GetTree().Paused = true;
		}
		else{
			GetTree().Paused = false;
		}
	}
}

	public void IncrementarPuntos()
	{
		puntos += 10;
		//GD.Print("Puntos " + score);
		interfaz iu = GetNode<interfaz>("/root/EscenaJuego/CanvasLayer/Interfaz");
		iu.ActualizarPuntos(puntos);

	}

	public Vector2 GetPosicionPersonaje()
	{
		return player.Position;
	}
}
