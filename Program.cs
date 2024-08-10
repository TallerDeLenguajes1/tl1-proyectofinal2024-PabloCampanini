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
List<Personaje> personajes = fabrica.CrearEnemigos();
personajes.Add(personajeUsuario);
// Mostrar datos de todos los personajes
MostrarPersonaje mostrar = new MostrarPersonaje();
Console.WriteLine("Lista de personajes:");
foreach (var personaje in personajes)
{
    mostrar.MostrarDatosPersonaje(personaje);
    Console.WriteLine("----------------------------");
}

// Guardar los datos de los personajes en un archivo JSON
HelperDeJson jsonHelper = new HelperDeJson();
jsonHelper.GuardarArchivoJson("datosPersonajes.json", personajes);

// Leer los datos desde el archivo JSON
List<Personaje> personajesCargados = jsonHelper.AbrirArchivoJson<List<Personaje>>("datosPersonajes.json");
Console.WriteLine("\nPersonajes cargados desde el archivo JSON:");
foreach (var personaje in personajesCargados)
{
    mostrar.MostrarDatosPersonaje(personaje);
    Console.WriteLine("----------------------------");
}

// Realizar el torneo
Torneo torneo = new Torneo();
Personaje ganador = await torneo.RealizarTorneo(personajes);

// Mostrar datos del ganador
Console.WriteLine("\nEl ganador del torneo es:");
mostrar.MostrarDatosPersonaje(ganador);


string hola = Console.ReadLine();