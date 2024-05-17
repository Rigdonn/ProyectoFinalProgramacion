using Godot;
using System;
using System.Numerics;
using System.Threading;
using Vector2 = Godot.Vector2;

public partial class escena_juego : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private int puntos = 0;
	private mainPlayer player;
	private PackedScene mainMenu;
	public override void _Ready()
	{
		mainMenu = GD.Load<PackedScene>("res://Menu/main_menu.tscn");
		player = GetNode<mainPlayer>("/root/EscenaJuego/MainPlayer");
		GD.Randomize();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
public override void _Process(double delta)
{	
	
	if (Input.IsKeyPressed(Godot.Key.Space))
	{
	}
	if(Input.IsKeyPressed(Godot.Key.Escape)){
		GetTree().ChangeSceneToFile("res://Menu/main_menu.tscn");
	}
	FinalCaidaAlVacio();
}
	public void FinalCaidaAlVacio(){
		if (player.Position.Y >= 800){
			GetTree().ReloadCurrentScene();
		}
	}

	public void IncrementarPuntos()
	{
		puntos += 1;
		interfaz iu = GetNode<interfaz>("/root/EscenaJuego/CanvasLayer/Interfaz");
		iu.ActualizarPuntos(puntos);
		iu.TerminarPartida(puntos);

	}

	public Vector2 GetPosicionPersonaje()
	{
		return player.Position;
	}
}
