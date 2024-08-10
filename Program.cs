// See https://aka.ms/new-console-template for more information
using System.Text;
using EspacioPersonaje;
using EspacioFabricaDePersonajes;
using MostrarDatos;
using JsonHelper;
using EspacioTorneo;
using EspacioMenuPrincipal;

Console.OutputEncoding = Encoding.UTF8; // Establecer la codificación de la consola a UTF-8

// Mostrar el menú de inicio
MenuPrincipal menu = new MenuPrincipal();
menu.MostrarMenu();

// Crear una instancia de HelperDeJson
HelperDeJson jsonHelper = new HelperDeJson();
MostrarPersonaje mostrar = new MostrarPersonaje();
FabricaDePersonajes fabrica = new FabricaDePersonajes();
Torneo torneo = new Torneo();

// Leer opción del menú
switch (menu.OpcionSeleccionada)
{
    case 1: // Iniciar partida nueva
        // Crear un personaje para el usuario
        Personaje personajeUsuario = fabrica.CrearPersonajeUsuario();

        // Crear personajes enemigos
        List<Personaje> personajes = fabrica.CrearEnemigos();
        personajes.Add(personajeUsuario);

        // Mostrar datos de todos los personajes
        Console.WriteLine("Lista de personajes:");
        foreach (var personaje in personajes)
        {
            mostrar.MostrarDatosPersonaje(personaje);
            Console.WriteLine("----------------------------");
        }

        // Guardar los datos de los personajes en un archivo JSON
        jsonHelper.GuardarArchivoJson("datosPersonajes.json", personajes);
        Console.WriteLine("Datos de personajes guardados en 'datosPersonajes.json'.");

        // Realizar el torneo
        Personaje ganador = await torneo.RealizarTorneo(personajes);

        // Mostrar datos del ganador
        Console.WriteLine("\nEl ganador del torneo es:");
        mostrar.MostrarDatosPersonaje(ganador);
        break;

    case 2: // Cargar partida
        // Leer los datos desde el archivo JSON
        List<Personaje> personajesCargados = jsonHelper.AbrirArchivoJson<List<Personaje>>("datosPersonajes.json");
        Console.WriteLine("\nPersonajes cargados desde el archivo JSON:");
        foreach (var personaje in personajesCargados)
        {
            mostrar.MostrarDatosPersonaje(personaje);
            Console.WriteLine("----------------------------");
        }

        // Realizar el torneo con los personajes cargados
        Personaje ganadorCargado = await torneo.RealizarTorneo(personajesCargados);

        // Mostrar datos del ganador
        Console.WriteLine("\nEl ganador del torneo es:");
        mostrar.MostrarDatosPersonaje(ganadorCargado);
        break;

    case 3: // Salir
        Console.WriteLine("Saliendo del juego...");
        Environment.Exit(0);
        break;

    default:
        Console.WriteLine("Opción no válida.");
        break;
}

Console.ReadLine();