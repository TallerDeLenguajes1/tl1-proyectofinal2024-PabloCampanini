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
}