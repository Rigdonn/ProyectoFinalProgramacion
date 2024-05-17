using Godot;
using System;
using System.Collections.Generic;

public partial class Comida : Area2D
{
    private List<AudioStreamPlayer2D> sonidosComer = new List<AudioStreamPlayer2D>();
    private const int numComidas = 26;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Agregar los AudioStreamPlayer2D a la Lista
        for (int i = 1; i <= numComidas; i++)
        {
            AudioStreamPlayer2D sonido = GetNode<AudioStreamPlayer2D>($"/root/EscenaJuego/Comida{i}/AudioStreamPlayer2D");
            sonidosComer.Add(sonido);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
    
    private void _on_body_entered(CharacterBody2D otro)
    {
        if (otro.Name == "MainPlayer") 
        {
            GD.Print("Chocado");
            GetParent().Call("IncrementarPuntos");
			QueueFree();
            // Reproducir cada sonido en de la lista
            foreach (AudioStreamPlayer2D sonido in sonidosComer)
            {
				if (sonido != null){
					sonido.Play();
				}
            }
        }
    }
}
