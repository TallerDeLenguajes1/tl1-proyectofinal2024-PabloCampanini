namespace EspacioPersonaje;

using DatosYCaracteristicas;

public class Personaje
{
    //Campos
    private Datos datos;
    private Caracteristicas caracteristicas;

    //Constructor de un personaje
    public Personaje(Datos datosPersonaje, Caracteristicas caracteristicasPersonaje)
    {
        this.Datos= datos;
        this.Caracteristicas= caracteristicas;
    }

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
}