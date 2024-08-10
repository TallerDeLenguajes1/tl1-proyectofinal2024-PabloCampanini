namespace EspacioMenuPrincipal;
public class MenuPrincipal
{
    private int opcionSeleccionada;
    public int OpcionSeleccionada { get => opcionSeleccionada; set => opcionSeleccionada = value; }

    public void MostrarMenu()
    {
        bool opcionValida = false;

        while (!opcionValida)
        {
            Console.Clear();
            // MostrarIntroduccion();
            MostrarBienvenida();
            opcionValida = MostrarOpciones();
        }
    }

    // private void MostrarIntroduccion()
    // {
    //     // Guardar los colores actuales
    //     ConsoleColor fondoOriginal = Console.BackgroundColor;
    //     ConsoleColor textoOriginal = Console.ForegroundColor;

    //     // Establecer el color de fondo negro y el texto en naranja
    //     Console.BackgroundColor = ConsoleColor.Black;
    //     Console.ForegroundColor = ConsoleColor.DarkYellow; // Usar un color de texto naranja

    //     // Limpiar la consola para aplicar el fondo a toda la pantalla
    //     Console.Clear();

    //     // Introducción del juego
    //     string introduccion = "Cada cinco años, un gran torneo se celebra en la vasta y mística tierra de Eldoria.\n" +
    //                           "Este evento épico reúne a los más valientes y poderosos de todos los rincones del mundo\n" +
    //                           "para competir por el honor de gobernar. En juego está el control supremo sobre Eldoria,\n" +
    //                           "una tierra rica en magia y leyendas. Solo el campeón del torneo obtendrá el trono y el derecho a reinar sobre todos los reinos que la componen.";

    //     // Mostrar la introducción caracter a caracter
    //     foreach (char c in introduccion)
    //     {
    //         Console.Write(c);
    //         // Pausa para que el texto se muestre caracter a caracter
    //         Thread.Sleep(50); // Aumentar el valor para hacer el texto más lento
    //     }

    //     // Salto de línea antes del título
    //     Console.WriteLine("\n");

    //     // Pausa antes de borrar la pantalla y mostrar el título
    //     Console.WriteLine("Preparando el juego...");
    //     Thread.Sleep(3000); // Pausa de 3 segundos

    //     // Limpiar la consola
    //     Console.Clear();

    //     // Restaurar los colores originales
    //     Console.ForegroundColor = ConsoleColor.DarkYellow;
    //     Console.BackgroundColor = ConsoleColor.Black;
    // }

    private void MostrarBienvenida()
    {
        // Guardar los colores actuales
        ConsoleColor fondoOriginal = Console.BackgroundColor;
        ConsoleColor textoOriginal = Console.ForegroundColor;

        // Establecer el color de fondo negro y el texto en naranja
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.DarkYellow; // Usar un color de texto naranja

        // Limpiar la consola para aplicar el fondo a toda la pantalla
        Console.Clear();

        // Título del juego
        string titulo = "Batalla por el Trono";
        string subtitulo = "¿Quién reinará los 5 reinos?";

        // Mostrar título en grande
        string linea = new string('═', Console.WindowWidth);
        Console.WriteLine(linea);
        Console.WriteLine($"{titulo.PadLeft((Console.WindowWidth - titulo.Length) / 2 + titulo.Length).PadRight(Console.WindowWidth)}");
        Console.WriteLine();
        Console.WriteLine($"{subtitulo.PadLeft((Console.WindowWidth - subtitulo.Length) / 2 + subtitulo.Length).PadRight(Console.WindowWidth)}");
        Console.WriteLine(linea);

        // Restaurar los colores originales
        Console.ForegroundColor = textoOriginal;
        Console.BackgroundColor = fondoOriginal;
    }

    private bool MostrarOpciones()
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
                "1. Iniciar partida nueva",
                "2. Cargar partida",
                "3. Cargar historial de campeones",
                "4. Salir"
        };

        foreach (string opcion in opciones)
        {
            int textoAncho = opcion.Length;
            int textoInicio = (ancho - textoAncho) / 2;
            string lineaContenido = $"{bordeVertical}{opcion.PadLeft(textoInicio + textoAncho).PadRight(ancho - 1)}{bordeVertical}";
            Console.WriteLine(lineaContenido.PadLeft(margen + ancho + 2));
        }

        Console.WriteLine($"{esquinaInferiorIzquierda}{lineaHorizontal}{esquinaInferiorDerecha}".PadLeft(margen + ancho + 2));

        // Leer la opción del usuario
        Console.ResetColor();
        Console.Write("Seleccione una opción (1, 2, 3, 4): ");
        string input = Console.ReadLine();
        return ProcesarOpcion(input);
    }

    private bool ProcesarOpcion(string opcion)
    {
        switch (opcion)
        {
            case "1":
                OpcionSeleccionada = 1;
                Console.WriteLine("Iniciar partida nueva...");
                return true;
            case "2":
                OpcionSeleccionada = 2;
                // Verificar si existe el archivo de la partida guardada
                if (File.Exists("datosPersonajes.json"))
                {
                    Console.WriteLine("Cargando partida...");
                    return true;
                }
                else
                {
                    Console.WriteLine("No hay partida guardada.");
                    Thread.Sleep(2000); // Pausa de 2 segundos para que el usuario lea el mensaje
                    return false; // Regresar al menú
                }
            case "3":
                OpcionSeleccionada = 3;
                return true;
            case "4":
                MostrarAgradecimiento();
                return true;
            default:
                Console.WriteLine("Opción no válida. Por favor, seleccione 1, 2, 3 o 4.");
                return false;
        }
    }

    public void MostrarAgradecimiento()
    {
        // Limpiar la consola
        Console.Clear();

        // Guardar los colores actuales
        ConsoleColor fondoOriginal = Console.BackgroundColor;
        ConsoleColor textoOriginal = Console.ForegroundColor;

        // Establecer el color de fondo negro y el texto en naranja
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.DarkYellow;

        // Mensaje de agradecimiento
        string mensaje = "Gracias por jugar";

        // Calcular la posición centrada horizontal y verticalmente
        int anchoMensaje = mensaje.Length;
        int anchoVentana = Console.WindowWidth;
        int altoVentana = Console.WindowHeight;
        int posX = (anchoVentana - anchoMensaje) / 2;
        int posY = altoVentana / 2;

        // Mover el cursor a la posición calculada
        Console.SetCursorPosition(posX, posY);

        // Mostrar el mensaje
        Console.WriteLine(mensaje);

        // Restaurar los colores originales
        Console.ForegroundColor = textoOriginal;
        Console.BackgroundColor = fondoOriginal;

        // Pausa para que el usuario vea el mensaje
        Thread.Sleep(3000); // Pausa de 3 segundos

        // Limpiar la consola antes de salir
        Console.Clear();

        Environment.Exit(0);
    }
}
