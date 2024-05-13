using Godot;
using System;

public partial class Enemigo : CharacterBody2D
{
	public const float Speed = -60f;

	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public bool derecha = false;

	private Sprite2D sprite;

	public RayCast2D sueloRaycast1;
	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("/root/EscenaJuego/Enemigo/Sprite2D");
		sueloRaycast1 = GetNode<RayCast2D>("/root/EscenaJuego/Enemigo/RayCast2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (!IsOnFloor()){
			velocity.Y += gravity * (float)delta;
		}
		else{
			velocity.X = -gravity * (float)delta + Speed;
		}

		if(!sueloRaycast1.IsColliding() && IsOnFloor()){
			velocity.X = gravity * (float)delta;
		}



		Velocity = velocity;
		MoveAndSlide();
	}
}
