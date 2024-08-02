namespace DatosYCaracteristicas;

public class Datos
{
    //Campos
    private string nombre, apodo;
    private DateTime fechaDeNacimiento;
    private int edad;   //Entre 0 a 300
    private string raza;

    //Constructor
    public Datos(string raza, string nombre, string apodo, DateTime fechaDeNacimiento, int edad)
    {
        this.Nombre = nombre;
        this.Apodo = apodo;
        this.FechaDeNacimiento = fechaDeNacimiento;
        this.Edad = edad;
        this.Raza = raza;
    }

    //Propiedades
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    public int Edad { get => edad; set => edad = value; }
    public string Raza { get => raza; set => raza = value; }
}

public class Caracteristicas
{
    //Campos
    private int velocidad;  //1 a 10
    private int destreza;   //1 a 5
    private int fuerza;     //1 a 10
    private int nivel;      //1 a 10
    private int armadura;   //1 a 10
    private int salud;      //100

    //Propiedades
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }

    //Constructor
    public Caracteristicas(int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud)
    {
        this.Velocidad = velocidad;
        this.Destreza = destreza;
        this.Fuerza = fuerza;
        this.Nivel = nivel;
        this.Armadura = armadura;
        this.Salud = salud;
    }
}