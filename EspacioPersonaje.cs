namespace EspacioPersonaje;

using DatosYCaracteristicas;

public class Personaje
{
    //Campos
    private Datos datos;
    private Caracteristicas caracteristicas;

    //Propiedades
    public Datos Datos
    {
        get => datos;
        set => datos = value;
    }
    public Caracteristicas Caracteristicas
    {
        get => caracteristicas;
        set => caracteristicas = value;
    }

    //Constructor de un personaje
    public Personaje(Datos datos, Caracteristicas caracteristicas)
    {
        this.datos = datos;
        this.caracteristicas = caracteristicas;
    }

    //Metodos
    public double Ataque()
    {
        //Variable auxiliar
        double CalculoDaño = 0;
        int AjusteDaño = 300;

        CalculoDaño = (Caracteristicas.Destreza * Caracteristicas.Fuerza * Caracteristicas.Nivel) / (AjusteDaño);

        //Reduccion del daño debido a la salud
        if (Caracteristicas.Salud <= 50)
        {
            CalculoDaño *= 0.90;
        }

        return CalculoDaño;
    }

    public double Defensa()
    {
        double CalculoDefensa = 0;

        CalculoDefensa = (Caracteristicas.Armadura * Caracteristicas.Velocidad * (Caracteristicas.Destreza / Caracteristicas.Fuerza));

        //Reduccion de la defensa debido a la salud
        if (Caracteristicas.Salud <= 50)
        {
            CalculoDefensa *= 0.95;
        }

        return CalculoDefensa;
    }
}