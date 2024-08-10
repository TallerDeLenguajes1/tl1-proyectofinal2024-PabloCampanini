namespace EspacioHistorial;

using JsonHelper;
using EspacioPersonaje;

public class HistorialGanadores
{
    private const string HistorialArchivo = "historialCampeones.json";
    private readonly HelperDeJson jsonHelper = new HelperDeJson(); // Instancia de HelperDeJson

    public void CargarHistorialDeCampeones()
    {
        // Limpiar la consola
        Console.Clear();

        // Guardar los colores actuales
        ConsoleColor fondoOriginal = Console.BackgroundColor;
        ConsoleColor textoOriginal = Console.ForegroundColor;

        // Establecer el color de fondo negro y el texto en naranja
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.DarkYellow;

        // Mostrar título
        string titulo = "Historial de Campeones";
        string linea = new string('═', Console.WindowWidth);
        Console.WriteLine(linea);
        Console.WriteLine($"{titulo.PadLeft((Console.WindowWidth - titulo.Length) / 2 + titulo.Length).PadRight(Console.WindowWidth)}");
        Console.WriteLine(linea);

        // Cargar y mostrar el historial de campeones
        if (File.Exists(HistorialArchivo))
        {
            var historial = jsonHelper.AbrirArchivoJson<List<Dictionary<string, object>>>(HistorialArchivo);

            foreach (var registro in historial)
            {
                MostrarTextoCaracterPorCaracter($"Nombre: {registro["Nombre"]}");
                MostrarTextoCaracterPorCaracter($"Raza: {registro["Raza"]}");
                MostrarTextoCaracterPorCaracter($"Edad: {registro["Edad"]}");
                Console.WriteLine("----------------------------");
            }
        }
        else
        {
            MostrarTextoCaracterPorCaracter("No hay historial de campeones disponible.");
        }

        // Restaurar los colores originales
        Console.ForegroundColor = textoOriginal;
        Console.BackgroundColor = fondoOriginal;

        // Esperar 3 segundos antes de volver al menú
        Task.Delay(3000).Wait();
        Console.Clear(); // Limpiar la consola antes de volver al menú
    }

    private void MostrarTextoCaracterPorCaracter(string texto)
    {
        foreach (char c in texto)
        {
            Console.Write(c);
            Thread.Sleep(30); // Ajusta la velocidad de la visualización
        }
        Console.WriteLine(); // Nueva línea después de mostrar el texto
    }

    public void AgregarCampeonAlHistorial(Personaje ganador)
    {
        var nuevoRegistro = new Dictionary<string, object>
            {
                { "Nombre", ganador.Datos.Nombre },
                { "Raza", ganador.Datos.Raza },
                { "Edad", ganador.Datos.Edad }
            };

        List<Dictionary<string, object>> historial;
        if (File.Exists(HistorialArchivo))
        {
            historial = jsonHelper.AbrirArchivoJson<List<Dictionary<string, object>>>(HistorialArchivo);
        }
        else
        {
            historial = new List<Dictionary<string, object>>();
        }

        historial.Add(nuevoRegistro);

        jsonHelper.GuardarArchivoJson(HistorialArchivo, historial);
    }
}