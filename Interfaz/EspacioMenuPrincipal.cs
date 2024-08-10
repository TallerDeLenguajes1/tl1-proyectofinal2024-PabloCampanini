namespace EspacioMenuPrincipal
{
    public class Menu
    {
        public int OpcionSeleccionada { get; private set; }

        public void MostrarMenu()
        {
            bool opcionValida = false;

            while (!opcionValida)
            {
                Console.Clear();
                MostrarBienvenida();
                opcionValida = MostrarOpciones();
            }
        }

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
            string subtitulo = "¿Quién reinará los reinos?";

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
                "3. Salir"
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
            Console.Write("Seleccione una opción (1, 2, 3): ");
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
                    Console.WriteLine("Cargar partida...");
                    return true;
                case "3":
                    OpcionSeleccionada = 3;
                    Console.WriteLine("Saliendo del juego...");
                    return true;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione 1, 2 o 3.");
                    return false;
            }
        }
    }
}
