namespace MostrarDatos;

using EspacioPersonaje;
public class MostrarPersonaje
{
    public void MostrarDatosPersonaje(Personaje personaje)
    {
        Console.WriteLine($"\nNombre: {personaje.Datos.Nombre}");
        Console.WriteLine($"Apodo: {personaje.Datos.Apodo}");
        Console.WriteLine($"Fecha de Nacimiento: {personaje.Datos.FechaDeNacimiento.ToString("dd/MM/yyyy")}");
        Console.WriteLine($"Edad: {personaje.Datos.Edad}");
        Console.WriteLine($"Raza: {personaje.Datos.Raza}");
        Console.WriteLine($"Velocidad: {personaje.Caracteristicas.Velocidad}");
        Console.WriteLine($"Destreza: {personaje.Caracteristicas.Destreza}");
        Console.WriteLine($"Fuerza: {personaje.Caracteristicas.Fuerza}");
        Console.WriteLine($"Nivel: {personaje.Caracteristicas.Nivel}");
        Console.WriteLine($"Armadura: {personaje.Caracteristicas.Armadura}");
        Console.WriteLine($"Salud: {personaje.Caracteristicas.Salud}");
    }
}