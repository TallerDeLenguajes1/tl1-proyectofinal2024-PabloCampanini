namespace EspacioTorneo;

using EspacioPersonaje;
using EspacioPelea;
using SorteoGrupos;
using EspacioDados;
using ConectarApi;

public class Torneo
{
    // Campos
    private List<Personaje> siguienteRonda = new List<Personaje>();
    private TirarDados tirarDados = new TirarDados();

    // Propiedades
    public List<Personaje> SiguienteRonda { get => siguienteRonda; set => siguienteRonda = value; }
    public TirarDados TirarDados { get => tirarDados; set => tirarDados = value; }

    // Métodos
    public async Task Ronda1(List<Personaje> Participantes)
    {
        // Sortear batallas
        Sorteo sorteo = new Sorteo();
        Batalla batalla = new Batalla();

        sorteo.SortearBatallas(Participantes);

        int Indice = 0;
        int anchoCuadro = 60;  // Ancho de la caja para los combates
        string espaciosTerminal = new string(' ', (Console.WindowWidth - anchoCuadro) / 2);
        int anchoCuadroGanador = 80;  // Ancho de la caja para el ganador
        string espaciosTerminalGanador = new string(' ', (Console.WindowWidth - anchoCuadroGanador) / 2);

        while (sorteo.Grupos.Count > Indice)
        {
            List<Personaje> GrupoPelea = sorteo.Grupos[Indice];

            // Sorteo para determinar quién ataca primero
            Dados Dado = await TirarDados.GetDados(1, 20);

            // Mostrar el enfrentamiento
            string textoCombate = $"Combate entre {GrupoPelea[0].Datos.Nombre} y {GrupoPelea[1].Datos.Nombre}";
            int paddingIzquierdo = (anchoCuadro - 2 - textoCombate.Length) / 2; // Restamos 2 para las barras laterales
            string mensajeCombate = "║" + new string(' ', paddingIzquierdo) + textoCombate + new string(' ', anchoCuadro - 2 - paddingIzquierdo - textoCombate.Length) + "║";

            // Mostrar caja con el texto centrado
            Console.WriteLine("\n" + espaciosTerminal + "╔══════════════════════════════════════════════════════════╗");
            Console.WriteLine(espaciosTerminal + mensajeCombate);
            Console.WriteLine(espaciosTerminal + "╚══════════════════════════════════════════════════════════╝");

            Personaje GanadorBatalla;

            if (Dado.Result % 2 == 0)
            {
                GanadorBatalla = await batalla.CombateTotal(GrupoPelea[0], GrupoPelea[1]);
            }
            else
            {
                GanadorBatalla = await batalla.CombateTotal(GrupoPelea[1], GrupoPelea[0]);
            }

            GanadorBatalla.Caracteristicas.Salud = 100;
            SiguienteRonda.Add(GanadorBatalla);

            // Determinar el ataque específico basado en la raza
            string ataqueEspecifico = GanadorBatalla.Datos.Raza switch
            {
                "Humano" => "un golpe maestro",
                "Elfo" => "una flecha precisa",
                "Enano" => "un martillazo devastador",
                "Orco" => "un hachazo brutal",
                "Hobbit" => "una puñalada sigilosa",
                _ => "un ataque inesperado"
            };

            // Mostrar el mensaje del ganador
            string textoGanador = $"El ganador del combate es {GanadorBatalla.Datos.Nombre} con {ataqueEspecifico}!";
            int paddingIzquierdoGanador = (anchoCuadroGanador - 2 - textoGanador.Length) / 2; // Restamos 2 para las barras laterales
            string mensajeGanador = "║" + new string(' ', paddingIzquierdoGanador) + textoGanador + new string(' ', anchoCuadroGanador - 2 - paddingIzquierdoGanador - textoGanador.Length) + "║";

            // Mostrar caja con el texto centrado
            Console.WriteLine(espaciosTerminalGanador + "╔════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(espaciosTerminalGanador + mensajeGanador);
            Console.WriteLine(espaciosTerminalGanador + "╚════════════════════════════════════════════════════════════════════════════════╝");

            // Esperar 3 segundos para mostrar el mensaje del ganador
            await Task.Delay(3000);

            // Mostrar mensaje de carga para el próximo combate
            Console.WriteLine("\nCargando próximo combate...");
            await Task.Delay(2000);  // Espera de 2 segundos

            Indice++;
        }
    }

    public async Task RondaN()
    {
        Batalla batalla = new Batalla();
        int anchoCuadro = 60;  // Ancho de la caja para los combates
        string espaciosTerminal = new string(' ', (Console.WindowWidth - anchoCuadro) / 2);
        int anchoCuadroGanador = 80;  // Ancho de la caja para el ganador
        string espaciosTerminalGanador = new string(' ', (Console.WindowWidth - anchoCuadroGanador) / 2);

        while (SiguienteRonda.Count > 1)
        {
            List<Personaje> GanadoresRonda = new List<Personaje>();

            int CantidadCombates = SiguienteRonda.Count / 2;

            for (int i = 0; i < CantidadCombates; i++)
            {
                // Mostrar el enfrentamiento
                string textoCombate = $"Combate entre {SiguienteRonda[i * 2].Datos.Nombre} y {SiguienteRonda[(i * 2) + 1].Datos.Nombre}";
                int paddingIzquierdo = (anchoCuadro - 2 - textoCombate.Length) / 2; // Restamos 2 para las barras laterales
                string mensajeCombate = "║" + new string(' ', paddingIzquierdo) + textoCombate + new string(' ', anchoCuadro - 2 - paddingIzquierdo - textoCombate.Length) + "║";

                // Mostrar caja con el texto centrado
                Console.WriteLine("\n" + espaciosTerminal + "╔══════════════════════════════════════════════════════════╗");
                Console.WriteLine(espaciosTerminal + mensajeCombate);
                Console.WriteLine(espaciosTerminal + "╚══════════════════════════════════════════════════════════╝");

                // Sorteo para determinar quién ataca primero
                Dados Dado = await TirarDados.GetDados(1, 20);

                Personaje GanadorBatalla;

                if (Dado.Result % 2 == 0)
                {
                    GanadorBatalla = await batalla.CombateTotal(SiguienteRonda[i * 2], SiguienteRonda[(i * 2) + 1]);
                }
                else
                {
                    GanadorBatalla = await batalla.CombateTotal(SiguienteRonda[(i * 2) + 1], SiguienteRonda[i * 2]);
                }

                GanadorBatalla.Caracteristicas.Salud = 100;
                GanadoresRonda.Add(GanadorBatalla);

                // Determinar el ataque específico basado en la raza
                string ataqueEspecifico = GanadorBatalla.Datos.Raza switch
                {
                    "Humano" => "un golpe maestro",
                    "Elfo" => "una flecha precisa",
                    "Enano" => "un martillazo devastador",
                    "Orco" => "un hachazo brutal",
                    "Hobbit" => "una puñalada sigilosa",
                    _ => "un ataque inesperado"
                };

                // Mostrar el mensaje del ganador
                string textoGanador = $"El ganador del combate es {GanadorBatalla.Datos.Nombre} con {ataqueEspecifico}!";
                int paddingIzquierdoGanador = (anchoCuadroGanador - 2 - textoGanador.Length) / 2; // Restamos 2 para las barras laterales
                string mensajeGanador = "║" + new string(' ', paddingIzquierdoGanador) + textoGanador + new string(' ', anchoCuadroGanador - 2 - paddingIzquierdoGanador - textoGanador.Length) + "║";

                // Mostrar caja con el texto centrado
                Console.WriteLine(espaciosTerminalGanador + "╔════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine(espaciosTerminalGanador + mensajeGanador);
                Console.WriteLine(espaciosTerminalGanador + "╚════════════════════════════════════════════════════════════════════════════════╝");

                // Esperar 3 segundos para mostrar el mensaje del ganador
                await Task.Delay(3000);

                // Mostrar mensaje de carga para el próximo combate
                Console.WriteLine("\nCargando próximo combate...");
                await Task.Delay(2000);  // Espera de 2 segundos
            }

            SiguienteRonda = GanadoresRonda;
        }
    }

    public async Task<Personaje> RealizarTorneo(List<Personaje> Participantes)
    {
        // Realizar sorteos de los grupos de la primera ronda y las batallas de la primera ronda
        await Ronda1(Participantes);

        // Realizar rondas adicionales hasta que haya un ganador
        await RondaN();

        // SiguienteRonda queda con un solo personaje cargado, el campeón
        return SiguienteRonda[0];
    }
}