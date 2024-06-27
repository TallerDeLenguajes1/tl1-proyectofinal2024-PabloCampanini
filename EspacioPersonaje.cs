using DatosYCaracteristicas;

public class Personaje
{
    //Campos
    private Datos datosPersonaje;
    private Caracteristicas caracteristicasPersonaje;

    //Constructor de un personaje
    public Personaje(Datos datosPersonaje, Caracteristicas caracteristicasPersonaje)
    {
        this.DatosPersonaje = datosPersonaje;
        this.CaracteristicasPersonaje = caracteristicasPersonaje;
    }

    //Propiedades
    public Datos DatosPersonaje
    {
        get => datosPersonaje;
        set => datosPersonaje = value;
    }
    public Caracteristicas CaracteristicasPersonaje
    {
        get => caracteristicasPersonaje;
        set => caracteristicasPersonaje = value;
    }
}