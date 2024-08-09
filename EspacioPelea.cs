namespace EspacioPelea;

using EspacioPersonaje;

public class Batalla
{
    //Campos
    private Personaje atacante;
    private Personaje defensor;

    //Propiedades
    public Personaje Atacante { get => atacante; set => atacante = value; }
    public Personaje Defensor { get => defensor; set => defensor = value; }

    //Metodo
    public void TurnoBatalla(Personaje Ataca, Personaje Defiende)
    {
        int Daño = (int)(Ataca.Ataque() - Defiende.Defensa());

        //Al daño luego lo modificare con una api que proporciona tiradas de dados para obtener probabilidades de criticos o de esquivadas

        Defiende.Caracteristicas.Salud -= Daño;
    }

    public Personaje CombateTotal(Personaje Ataca, Personaje Defiende)
    {
        while (Ataca.Caracteristicas.Salud != 0 && Defiende.Caracteristicas.Salud != 0)
        {
            TurnoBatalla(Ataca, Defiende);

            if (Defiende.Caracteristicas.Salud != 0)
            {
                TurnoBatalla(Defiende, Ataca);
            }
        }

        if (Defiende.Caracteristicas.Salud != 0)
        {
            return Defiende;
        }
        else
        {
            return Ataca;
        }
    }
}