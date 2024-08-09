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
    public double Ataque(Personaje Atacante)
    {
        //Variable auxiliar
        double CalculoDaño = 0;
        int AjusteDaño = 300;

        CalculoDaño = (Atacante.Caracteristicas.Destreza * Atacante.Caracteristicas.Fuerza * Atacante.Caracteristicas.Nivel) / (AjusteDaño);

        //Reduccion del daño debido a la salud
        if (Atacante.Caracteristicas.Salud <= 50)
        {
            CalculoDaño *= 0.90;
        }

        return CalculoDaño;
    }

    public double Defensa(Personaje Defensor)
    {
        double CalculoDefensa = 0;

        CalculoDefensa = (Defensor.Caracteristicas.Armadura * Defensor.Caracteristicas.Velocidad * (Defensor.Caracteristicas.Destreza / Defensor.Caracteristicas.Fuerza));

        //Reduccion de la defensa debido a la salud
        if (Defensor.Caracteristicas.Salud <= 50)
        {
            CalculoDefensa *= 0.95;
        }

        return CalculoDefensa;
    }
}