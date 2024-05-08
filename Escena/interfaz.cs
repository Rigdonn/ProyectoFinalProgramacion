using Godot;
using System;

public partial class interfaz : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ActualizarPuntos(int valor){
		Label texto = GetNode<Label>("TextoPuntos"); ///root/EscenaJuego/CanvasLayer/Interfaz/"TextoPuntos?
		texto.Text = "Manzanas:" + valor;
	}

	public void TerminarPartida(int valor){
		if (valor >= 5){
			GetTree().ChangeSceneToFile("res://Menu/main_menu.tscn");
		}
	}
}
