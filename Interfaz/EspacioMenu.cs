namespace EspacioMenu
{
    public class Menu
    {
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
            // Título del juego
            string titulo = "Batalla por el Trono";
            string subtitulo = "¿Quién reinará los reinos?";

            // Mostrar título en grande
            Console.WriteLine("══════════════════════════════════════════════════");
            Console.WriteLine($"═ {titulo.PadLeft((Console.WindowWidth - titulo.Length) / 2 + titulo.Length).PadRight(Console.WindowWidth - 1)} ═");
            Console.WriteLine($"═ {subtitulo.PadLeft((Console.WindowWidth - subtitulo.Length) / 2 + subtitulo.Length).PadRight(Console.WindowWidth - 1)} ═");
            Console.WriteLine("══════════════════════════════════════════════════");
            Console.WriteLine();
        }

        private bool MostrarOpciones()
        {
            Console.WriteLine("1. Iniciar partida nueva");
            Console.WriteLine("2. Cargar partida");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción (1, 2, 3): ");
            
            // Leer la opción del usuario
            string input = Console.ReadLine();
            return ProcesarOpcion(input);
        }

        private bool ProcesarOpcion(string opcion)
        {
            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Iniciar partida nueva...");
                    // Aquí iría la lógica para iniciar una nueva partida
                    return true;
                case "2":
                    Console.WriteLine("Cargar partida...");
                    // Aquí iría la lógica para cargar una partida existente
                    return true;
                case "3":
                    Console.WriteLine("Saliendo del juego...");
                    // Aquí iría la lógica para salir del juego
                    Environment.Exit(0);
                    return true;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione 1, 2 o 3.");
                    return false;
            }
        }
    }
}
