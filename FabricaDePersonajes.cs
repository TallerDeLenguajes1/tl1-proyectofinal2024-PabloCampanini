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

    //Constructor
    public FabricaDePersonajes(Personaje personajeDelUsuario, List<Personaje> enemigos)
    {
        this.personajeDelUsuario = personajeDelUsuario;
        this.enemigos = enemigos;
    }

    //Metodos
    public Personaje CrearPersonajeUsuario()
    {
        Console.WriteLine("\n\t*---------- GENERACION DE SU PERSONAJE ----------*");

        //*----- CARGADO DE NOMBRE -----*
        Console.WriteLine("Ingrese el nombre de su personaje: ");
        string NombreUsuario = Console.ReadLine();

        //*----- CARGADO DE APODO -----*
        Console.WriteLine("¿Quiere ingresar un apodo? S/N");
        string IngresaApodo = Console.ReadLine();

        string ApodoUsuario;

        if (IngresaApodo == "s" || IngresaApodo == "S")
        {
            Console.WriteLine($"Ingrese su apodo {PersonajeDelUsuario.Datos.Nombre}: ");
            ApodoUsuario = Console.ReadLine();
        }
        else
        {
            ApodoUsuario = "";
        }

        //*----- CARGADO DE FECHA DE NACIMIENTO Y EDAD -----*
        bool control = true;
        DateTime NacimientoUsuario = DateTime.MinValue;
        int EdadUsuario = 0;

        while (control)
        {
            Console.WriteLine("Ingrese su fecha de nacimiento con formato (dd/MM/yyyy): ");

            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime FechaNacimiento))
            {
                NacimientoUsuario = FechaNacimiento;

                if (FechaNacimiento.Month > DateTime.Now.Date.Month)
                {
                    EdadUsuario = DateTime.Now.Date.Year - FechaNacimiento.Year - 1;
                }
                else
                {
                    if (FechaNacimiento.Month < DateTime.Now.Date.Month)
                    {
                        EdadUsuario = DateTime.Now.Date.Year - FechaNacimiento.Year;
                    }
                    else
                    {
                        if (FechaNacimiento.Day < DateTime.Now.Date.Day)
                        {
                            EdadUsuario = DateTime.Now.Date.Year - FechaNacimiento.Year - 1;
                        }
                        else
                        {
                            EdadUsuario = DateTime.Now.Date.Year - FechaNacimiento.Year;
                        }
                    }
                }

                control = false;
            }
            else
            {
                Console.WriteLine("No se ingreso un dato valido");
            }
        }

        //*----- ELECCION DE RAZA -----*
        control = true;
        string RazaUsuario = "";

        while (control)
        {
            Console.WriteLine("Seleccione el numero de la raza que quiere usar: ");
            Console.WriteLine("\n\t\t1. Humano\n\t\t2. Elfo\n\t\t3. Enano\n\t\t4. Orco\n\t\t5. Hobbit");

            string numRaza = Console.ReadLine();


            if (int.TryParse(numRaza, out int elegida))
            {
                switch (elegida)
                {
                    case 1:
                        control = false;
                        RazaUsuario = "Humano";
                        break;
                    case 2:
                        control = false;
                        RazaUsuario = "Elfo";
                        break;
                    case 3:
                        control = false;
                        RazaUsuario = "Enano";
                        break;
                    case 4:
                        control = false;
                        RazaUsuario = "Orco";
                        break;
                    case 5:
                        control = false;
                        RazaUsuario = "Hobbit";
                        break;
                    default:
                        Console.WriteLine("\n\t*-----El numero ingresado no corresponde a una raza valida -----*");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n\t*----- No ingreso un dato valido -----*");
            }
        }

        Datos DatosUsuario = new Datos(RazaUsuario, NombreUsuario, ApodoUsuario, NacimientoUsuario, EdadUsuario);

        //*----- CARGADO DE CARACTERISTICAS DE MANERA ALEATORIA -----*
        Caracteristicas CaracteristicasUsuario = new Caracteristicas(
            random.Next(1, 11), //Velocidad 1-10
            random.Next(1, 6),  //Destreza 1-5
            random.Next(1, 11), //Fuerza 1-10
            random.Next(1, 11), //Nivel 1-10
            random.Next(1, 11), //Armadura 1-10
            100                 //Salud 100
        );

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