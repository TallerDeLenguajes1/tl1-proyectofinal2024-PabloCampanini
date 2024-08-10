// See https://aka.ms/new-console-template for more information
using System.Text;
using EspacioPersonaje;
using EspacioFabricaDePersonajes;
using MostrarDatos;
using JsonHelper;
using EspacioTorneo;

Console.OutputEncoding = Encoding.UTF8; // Establecer la codificación de la consola a UTF-8

// Crear fábrica de personajes
FabricaDePersonajes fabrica = new FabricaDePersonajes();

// Crear un personaje para el usuario
Personaje personajeUsuario = fabrica.CrearPersonajeUsuario();

// Crear personajes enemigos
List<Personaje> enemigos = fabrica.CrearEnemigos();

enemigos.Add(personajeUsuario);

// Mostrar datos del personaje del usuario
MostrarPersonaje mostrar = new MostrarPersonaje();
mostrar.MostrarDatosPersonaje(personajeUsuario);

foreach (Personaje personaje in enemigos)
{
    mostrar.MostrarDatosPersonaje(personaje);
}

// Realizar el torneo
Torneo torneo = new Torneo();
Personaje ganador = await torneo.RealizarTorneo(enemigos);

// Mostrar datos del ganador
Console.WriteLine("\nEl ganador del torneo es:");
mostrar.MostrarDatosPersonaje(ganador);

string hola = Console.ReadLine();