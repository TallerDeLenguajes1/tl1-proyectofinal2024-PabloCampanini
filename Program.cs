// See https://aka.ms/new-console-template for more information
using System.Text;
using EspacioFabricaDePersonajes;
using DatosYCaracteristicas;
using EspacioPersonaje;

Console.OutputEncoding = Encoding.UTF8; // Establecer la codificación de la consola a UTF-8

// Crear la fábrica de personajes
FabricaDePersonajes fabrica = new FabricaDePersonajes(null, new List<Personaje>());

// Crear el personaje del usuario
Personaje personajeDelUsuario = fabrica.CrearPersonajeUsuario();
fabrica.PersonajeDelUsuario = personajeDelUsuario;

// Mostrar los datos del personaje del usuario
Console.WriteLine("\n\t*---------- DATOS DE SU PERSONAJE ----------*");
MostrarPersonaje(personajeDelUsuario);

// Crear la lista de enemigos
List<Personaje> enemigos = fabrica.CrearEnemigos();
fabrica.Enemigos = enemigos;

// Mostrar los datos de los enemigos
Console.WriteLine("\n\t*---------- LISTA DE ENEMIGOS ----------*");
foreach (var enemigo in enemigos)
{
    MostrarPersonaje(enemigo);
}

static void MostrarPersonaje(Personaje personaje)
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