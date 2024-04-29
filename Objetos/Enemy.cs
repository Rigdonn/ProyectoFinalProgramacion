using Godot;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

public partial class Enemy : Area2D
{
	// Called when the node enters the scene tree for the first time.
	private int speed;
	private escena_juego juego;
	public override void _Ready()
	{
		speed = 150;
		juego = GetNode<escena_juego>("/root/EscenaJuego");
		if (juego == null)
		{
			GD.PrintErr("No se puedo encontrar escena de juego");
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 posPersonaje = juego.GetPosicionPersonaje();
		Vector2 distancia = posPersonaje - Position;
		Position += distancia.Normalized() * speed * (float)delta;
		/*
		Position += speed * (float)delta;
		if(Position.X > 900){
			speed = new Vector2(-150,0);
			
		}
		if(Position.X < 100){
			speed = new Vector2(150,0);
		}*/
	}
}
