using Godot;
using System;
using System.IO;
public partial class main_menu : Control
{
	public StreamReader fichero;
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
		GetTree().ChangeSceneToFile("res://Escena/MenuOpciones.tscn"); //test_escene pero la renombré a MenuOpciones

	}
	
	private void _on_exit_pressed(){ //Para salir del juego desde la pantalla principal
		GD.Print("Salir");
		GetTree().Quit();
		
	}
	private void _on_new_game_pressed() //Para empezar nueva partida
	{
		GD.Print("Inicio");
		GetTree().ChangeSceneToFile("res://Escena/escena_juego.tscn");
	}
	private void _on_como_jugar_pressed() //Para cargar el fichero de como Jugar
	{
        // Para cargar el fichero de como Jugar
        GD.Print("Cargando instrucciones de 'Cómo Jugar'");

        string filePath = "res://Images/Otros/ComoJugar.txt";
        StreamReader miFichero = null;
        
        try
        {
            miFichero = new StreamReader(filePath);
            string contenido = miFichero.ReadToEnd();
            GD.Print(contenido); // Imprimir el contenido
            
        }
        catch (Exception ex)
        {
            GD.PrintErr($"Error al cargar el fichero: {ex.Message}");
        }
        finally
        {
            if (miFichero != null)
                miFichero.Close();
        }
	}
}
