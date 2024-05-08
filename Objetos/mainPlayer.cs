using Godot;
using System;

public partial class mainPlayer : CharacterBody2D
{
	public const float Speed = 300;
	public const float JumpVelocity = 380;

	private AnimationPlayer ap;
	private Sprite2D sprite;
	public bool agachado = false;
	public Shape2D standingCshape;
	public Shape2D crouchingCshape;
	public CollisionShape2D cshape;
	public RayCast2D crouchRaycast1;
	public RayCast2D crouchRaycast2;
	public bool personajeStucked = false;
	

	//public float horizontalDirection = Input.GetAxis("izquierda_a", "derecha_d");


	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		ap = GetNode<AnimationPlayer>("/root/EscenaJuego/MainPlayer/AnimationPlayer"); // cast para las animaciones
		sprite = GetNode<Sprite2D>("/root/EscenaJuego/MainPlayer/Sprite2D");
		standingCshape = GD.Load<Shape2D>("res://Resources/Player_standing_cshape.tres");
		crouchingCshape = GD.Load<Shape2D>("res://Resources/Player_crouching_cshape.tres");
		cshape = GetNode<CollisionShape2D>("/root/EscenaJuego/MainPlayer/CollisionShape2D");
		crouchRaycast1 = GetNode<RayCast2D>("/root/EscenaJuego/MainPlayer/CrouchingRaycast1");
		crouchRaycast2 = GetNode<RayCast2D>("/root/EscenaJuego/MainPlayer/CrouchingRaycast2");
	}

	public override void _Process(double delta)
	{	
		
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;
			if (velocity.Y > 1000){
				velocity.Y = 1000;
			}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump"))  // && IsOnFloor() para cuando tenga el suelo
			velocity.Y = -JumpVelocity; //variable de arriba

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direccion = Input.GetVector( "izquierda_a", "derecha_d", "ui_up", "ui_down");
		if (direccion != Vector2.Zero)
		{
			velocity.X = direccion.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		
		Velocity = velocity;
		//para controlar la mirada del personaje, si la velocidad es menor de X significa que no estoy tocando nada por lo tanto dejo el personaje mirando donde necesito
		bool izquierda = velocity.X < 0;
		if (velocity.X != 0){
			sprite.FlipH = izquierda;
		}
		if (Input.IsActionJustPressed("abajo_s")){
			Agacharse();
		}
		else if (Input.IsActionJustReleased("abajo_s")){
			if (EncimaPersonaje()){ //si no hay nada significa que es true por lo tanto puedo levantarme
				Levantarse();
			}
			else{
				if(personajeStucked != true){ //por si tengo algo encima no me deje levantarme
					personajeStucked = false;

				}
			}
		}
		if(personajeStucked && EncimaPersonaje()){ //si no estoy pulsando "S" pero ya no tengo nada encima se levanta automaticamente
			if(!Input.IsActionJustPressed("abajo_s")){
				Levantarse();
				personajeStucked = false;
			}
		}
		MoveAndSlide();
		 //si el personaje esta quieto, X == 0, hara la animacion idle, en caso contrario run, para la caida lo mismo pero controlando Y
		 //apunte: quería hacer una funcion para esto pero no me dejaba porque IsOnFloor() no me dejaba añadirla en la funcion.
		if (IsOnFloor()){
			if(velocity.X == 0){
				if(agachado){
					ap.Play("crouch");
				}
				else{
					ap.Play("idle");
				}
			}
			else{
				if(agachado){
					ap.Play("crouchWalk");
				}
				else{
					ap.Play("run");
				}
			}
		}
		else{
			if(agachado == false){

				if(velocity.Y < 0){
					ap.Play("jump");
				}
				else if (velocity.Y > 0){
					ap.Play("fall");
				}
			}
			else{
				ap.Play("crouch");
			}
		}
	}
	public void Agacharse(){
		int Y = 50;
		if (agachado){
			return;
		}
		agachado = true;
		cshape.Shape = crouchingCshape;
		cshape.Position = new Vector2(sprite.Position.X, Y);
	}
	public void Levantarse(){
		int Y = 36;
		if (agachado == false){
			return;
		}
		agachado = false;
		cshape.Shape = standingCshape;
		cshape.Position = new Vector2(sprite.Position.X, Y); //para que al agacharse la colision se ajuste al suelo.
	}
	public bool EncimaPersonaje(){ //si hay algo encima del personaje -> false
		return !crouchRaycast1.IsColliding() && !crouchRaycast2.IsColliding();
	} 
}
