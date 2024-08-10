namespace EspacioFabricaDePersonajes;

using System.Globalization;
using DatosYCaracteristicas;
using EspacioPersonaje;

public class FabricaDePersonajes
{
    //Campos
    private Personaje personajeDelUsuario;
    private List<Personaje> enemigos;
    private Random random = new Random();

    //Propiedades
    public Personaje PersonajeDelUsuario
    {
        get => personajeDelUsuario;
        set => personajeDelUsuario = value;
    }
    public List<Personaje> Enemigos
    {
        get => enemigos;
        set => enemigos = value;
    }

    //Metodos
    public Personaje CrearPersonajeUsuario()
    {

        Console.WriteLine("\n╔══════════════════════════════════════════════╗");
        Console.WriteLine("║          GENERACIÓN DE SU PERSONAJE          ║");
        Console.WriteLine("╚══════════════════════════════════════════════╝");

        // CARGADO DE NOMBRE
        Console.Write("\nIngrese el nombre de su personaje: ");
        string NombreUsuario = Console.ReadLine();

        // CARGADO DE APODO
        Console.Write("\n¿Quiere ingresar un apodo? S/N: ");
        string IngresaApodo = Console.ReadLine();
        string ApodoUsuario;

        if (IngresaApodo.Equals("s", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Ingrese su apodo: ");
            ApodoUsuario = Console.ReadLine();
        }
        else
        {
            ApodoUsuario = "";
        }

        // CARGADO DE FECHA DE NACIMIENTO Y EDAD
        bool control = true;
        DateTime NacimientoUsuario = DateTime.MinValue;
        int EdadUsuario = 0;

        while (control)
        {
            Console.Write("\nIngrese su fecha de nacimiento (dd/MM/yyyy): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime FechaNacimiento))
            {
                NacimientoUsuario = FechaNacimiento;

                EdadUsuario = DateTime.Now.Date.Year - FechaNacimiento.Year;
                if (FechaNacimiento.Date > DateTime.Now.AddYears(-EdadUsuario)) EdadUsuario--;

                control = false;
            }
            else
            {
                Console.WriteLine("\n\t*----- No se ingresó un dato válido -----*");
            }
        }

        // ELECCIÓN DE RAZA
        control = true;
        string RazaUsuario = "";

        while (control)
        {
            Console.WriteLine("\nSeleccione la raza de su personaje:");
            Console.WriteLine("\n\t1. Humano\n\t2. Elfo\n\t3. Enano\n\t4. Orco\n\t5. Hobbit");
            Console.Write("Opción: ");

            string numRaza = Console.ReadLine();

            if (int.TryParse(numRaza, out int elegida))
            {
                switch (elegida)
                {
                    case 1:
                        RazaUsuario = "Humano";
                        control = false;
                        break;
                    case 2:
                        RazaUsuario = "Elfo";
                        control = false;
                        break;
                    case 3:
                        RazaUsuario = "Enano";
                        control = false;
                        break;
                    case 4:
                        RazaUsuario = "Orco";
                        control = false;
                        break;
                    case 5:
                        RazaUsuario = "Hobbit";
                        control = false;
                        break;
                    default:
                        Console.WriteLine("\n\t*----- El número ingresado no corresponde a una raza válida -----*");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n\t*----- No se ingresó un dato válido -----*");
            }
        }

        Datos DatosUsuario = new Datos(RazaUsuario, NombreUsuario, ApodoUsuario, NacimientoUsuario, EdadUsuario);

        // CARGADO DE CARACTERÍSTICAS DE MANERA ALEATORIA
        Caracteristicas CaracteristicasUsuario = new Caracteristicas(
            random.Next(1, 11), // Velocidad 1-10
            random.Next(1, 6),  // Destreza 1-5
            random.Next(1, 11), // Fuerza 1-10
            random.Next(1, 11), // Nivel 1-10
            random.Next(1, 11), // Armadura 1-10
            100                 // Salud 100
        );

        Console.WriteLine("\n╔══════════════════════════════════════════════╗");
        Console.WriteLine("║         PERSONAJE GENERADO EXITOSAMENTE      ║");
        Console.WriteLine("╚══════════════════════════════════════════════╝");

        return new Personaje(DatosUsuario, CaracteristicasUsuario);
    }

    public List<Personaje> CrearEnemigos()
    {
        List<Personaje> ListaEnemigos = new List<Personaje>();

        DateTime fecha1 = DateTime.ParseExact("01/05/1904", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime fecha2 = DateTime.ParseExact("15/08/1874", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime fecha3 = DateTime.ParseExact("22/12/1929", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime fecha4 = DateTime.ParseExact("30/03/1864", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime fecha5 = DateTime.ParseExact("10/07/1994", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime fecha6 = DateTime.ParseExact("09/11/1979", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime fecha7 = DateTime.ParseExact("05/02/1954", "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Datos[] Enemigos =
        {
            new Datos("Elfo", "Aric Stone", "El Guardián", fecha1, 120),
            new Datos("Enano", "Gondar Brim", "El Martillo", fecha2, 150),
            new Datos("Elfo", "Lira Swift", "La Flecha", fecha3, 95),
            new Datos("Enano", "Borin Ironfist", "El Invencible", fecha4, 160),
            new Datos("Humano", "Sylas Thorn", "El Sombra", fecha5, 30),
            new Datos("Orco", "Eldric Storm", "El Viento", fecha6, 45),
            new Datos("Hobbit", "Fiona Greenshade", "La Sabia", fecha7, 70)
        };

        for (int i = 0; i < 7; i++)
        {
            Caracteristicas CaracteristicasEnemigo = new Caracteristicas(
                random.Next(1, 11), //Velocidad 1-10
                random.Next(1, 6),  //Destreza 1-5
                random.Next(1, 11), //Fuerza 1-10
                random.Next(1, 11), //Nivel 1-10
                random.Next(1, 11), //Armadura 1-10
                100                 //Salud 100
            );

            ListaEnemigos.Add(new Personaje(Enemigos[i], CaracteristicasEnemigo));
        }

        return ListaEnemigos;
    }
}