using Godot;
using System;
public partial class main_menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_options_pressed(){ //Botón de opciones
		GD.Print("Botón de Opciones");
		GetTree().ChangeSceneToFile("res://Escena/test_scene.tscn"); //test_escene pero la renombré a MenuOpciones

	}
	
	private void _on_exit_pressed(){ //Para salir del juego desde la pantalla principal
		GD.Print("Exit");
		GetTree().Quit();
		
	}
		private void _on_new_game_pressed() //Para empezar nueva partida
	{
		// Replace with function body.
		GD.Print("Play button");
		GetTree().ChangeSceneToFile("res://Escena/escena_juego.tscn");
	}
}
