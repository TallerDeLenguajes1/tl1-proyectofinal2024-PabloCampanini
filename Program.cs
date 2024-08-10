// See https://aka.ms/new-console-template for more information
using System.Text;
using EspacioPersonaje;
using EspacioFabricaDePersonajes;
using MostrarDatos;
using JsonHelper;
using EspacioTorneo;
using EspacioMenuPrincipal;
using EspacioHistorial;

Console.OutputEncoding = Encoding.UTF8; // Establecer la codificación de la consola a UTF-8

// Mostrar el menú de inicio
MenuPrincipal menu = new MenuPrincipal();
HistorialGanadores historialGanadores = new HistorialGanadores(); // Instancia de HistorialGanadores

// Crear una instancia de HelperDeJson
HelperDeJson jsonHelper = new HelperDeJson();
MostrarPersonaje mostrar = new MostrarPersonaje();
FabricaDePersonajes fabrica = new FabricaDePersonajes();
Torneo torneo = new Torneo();

while (true)
{
    menu.MostrarMenu();

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
            Console.WriteLine("\n╔══════════════════════════════════════════════╗");
            Console.WriteLine("║           COMPETIDORES DEL TORNEO            ║");
            Console.WriteLine("╚══════════════════════════════════════════════╝");

            foreach (var personaje in personajes)
            {
                mostrar.MostrarDatosPersonaje(personaje);
                Console.WriteLine("----------------------------");
                System.Threading.Thread.Sleep(1000); // Esperar 1 segundo entre cada bloque
            }

            // Guardar los datos de los personajes en un archivo JSON
            jsonHelper.GuardarArchivoJson("datosPersonajes.json", personajes);

            // Realizar el torneo
            Personaje ganador = await torneo.RealizarTorneo(personajes);

            // Mostrar datos del ganador
            Console.WriteLine("\nEl ganador del torneo es:");
            mostrar.MostrarDatosPersonaje(ganador);

            // Agregar el ganador al historial
            historialGanadores.AgregarCampeonAlHistorial(ganador);

            // Preguntar si desea salir o volver a jugar con estilo
            MostrarOpcionesFinales();

            int opcionFinal;
            while (!int.TryParse(Console.ReadLine(), out opcionFinal) || (opcionFinal != 1 && opcionFinal != 2))
            {
                Console.WriteLine("Opción no válida. Por favor, seleccione 1 o 2.");
            }

            if (opcionFinal == 2)
            {
                Console.Clear();
                Console.WriteLine("Gracias por jugar...");
                await Task.Delay(3000); // Esperar 3 segundos
                Environment.Exit(0);
            }
            else
            {
                File.Delete("datosPersonajes.json"); // Borrar el archivo de partida guardada
            }

            break;

        case 2: // Cargar partida
            if (File.Exists("datosPersonajes.json"))
            {
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

                // Agregar el ganador al historial
                historialGanadores.AgregarCampeonAlHistorial(ganadorCargado);

                // Preguntar si desea salir o volver a jugar con estilo
                MostrarOpcionesFinales();

                int opcionCargada;
                while (!int.TryParse(Console.ReadLine(), out opcionCargada) || (opcionCargada != 1 && opcionCargada != 2))
                {
                    Console.WriteLine("Opción no válida. Por favor, seleccione 1 o 2.");
                }

                if (opcionCargada == 2)
                {
                    menu.MostrarAgradecimiento();
                }
                else
                {
                    File.Delete("datosPersonajes.json"); // Borrar el archivo de partida guardada
                }
            }
            else
            {
                Console.WriteLine("No hay partida guardada para cargar.");
            }

            break;

        case 3: // Historial
            // Cargar y mostrar el historial de campeones
            historialGanadores.CargarHistorialDeCampeones();
            break;

        case 4: // Salir
            break;

        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

// Método para mostrar las opciones finales con estilo
void MostrarOpcionesFinales()
{
    // Establecer el color de fondo negro y el texto en naranja
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.DarkYellow;

    // Crear el recuadro para las opciones
    int ancho = 40; // Ancho del recuadro
    int margen = (Console.WindowWidth - ancho) / 2;
    string lineaHorizontal = new string('═', ancho - 1);
    string esquinaSuperiorIzquierda = "╔";
    string esquinaSuperiorDerecha = "╗";
    string esquinaInferiorIzquierda = "╚";
    string esquinaInferiorDerecha = "╝";
    string bordeVertical = "║";

    // Mostrar el recuadro y las opciones
    Console.WriteLine($"{esquinaSuperiorIzquierda}{lineaHorizontal}{esquinaSuperiorDerecha}".PadLeft(margen + ancho + 2));

    string[] opciones = new string[]
    {
        "1. Volver a jugar",
        "2. Salir"
    };

    foreach (string opcion in opciones)
    {
        string lineaConOpcion = $"{bordeVertical} {opcion}".PadRight(ancho) + $"{bordeVertical}";
        Console.WriteLine(lineaConOpcion.PadLeft(margen + ancho + 2));
    }

    Console.WriteLine($"{esquinaInferiorIzquierda}{lineaHorizontal}{esquinaInferiorDerecha}".PadLeft(margen + ancho + 2));

    // Restaurar colores originales
    Console.ResetColor();
}