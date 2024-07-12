namespace FabricaDePersonajes;

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
    public void CrearPersonajeUsuario(Datos datos, Caracteristicas caracteristicas)
    {
        int control = 1;

        Console.WriteLine("\n\t*---------- GENERACION DE SU PERSONAJE ----------*");

        //*----- ELECCION DE RAZA -----*
        while (control == 1)
        {
            Console.WriteLine("Seleccione el numero de la raza: ");
            Console.WriteLine("\n\t\t1. Humano\n\t\t2. Elfo\n\t\t3. Enano\n\t\t4. Orco\n\t\t5. Hobbit");

            string numRaza = Console.ReadLine();

            if (int.TryParse(numRaza, out int elegida))
            {
                switch (elegida)
                {
                    case 1:
                        control = 0;
                        datos.Raza = "Humano";
                        break;
                    case 2:
                        control = 0;
                        datos.Raza = "Elfo";
                        break;
                    case 3:
                        control = 0;
                        datos.Raza = "Enano";
                        break;
                    case 4:
                        control = 0;
                        datos.Raza = "Orco";
                        break;
                    case 5:
                        control = 0;
                        datos.Raza = "Hobbit";
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

        //*----- CARGADO DE NOMBRE -----*
        Console.WriteLine("Ingrese el nombre con el que sera llamado: ");
        datos.Nombre = Console.ReadLine();

        //*----- CARGADO DE APODO -----*
        Console.WriteLine("¿Quiere ingresar un apodo? S/N");
        string apodo = Console.ReadLine();

        if (apodo == "s" || apodo == "S")
        {
            Console.WriteLine($"Ingrese su apodo {datos.Nombre}: ");
            datos.Apodo = Console.ReadLine();
        }
        else
        {
            datos.Apodo = "";
        }

        //*----- CARGADO DE FECHA DE NACIMIENTO -----*
        control = 1;
        while (control == 1)
        {
            Console.WriteLine("Ingrese su fecha de nacimiento con formato (dd/MM/yyyy): ");

            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None, out DateTime anioIngresado))
            {
                datos.FechaDeNacimiento = anioIngresado;
                control = 0;
            }
            else
            {
                Console.WriteLine("No se ingreso un dato valido");
            }
        }

        
    }
}