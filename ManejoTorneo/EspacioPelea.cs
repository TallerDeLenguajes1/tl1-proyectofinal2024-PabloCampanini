namespace EspacioPelea;

using EspacioPersonaje;
using EspacioDados;
using ConectarApi;

public class Batalla
{
    //Metodo 
    public async Task TurnoBatalla(Personaje Ataca, Personaje Defiende)
    {
        TirarDados TirarDados = new TirarDados();
        Dados DadosAtacante = await TirarDados.GetDados(1, 20);
        Dados DadosDefensor = await TirarDados.GetDados(1, 20);

        int Daño;

        if (DadosAtacante.Result > DadosDefensor.Result)
        {
            Console.WriteLine($"{Ataca.Datos.Nombre} obtiene una bonificacion de daño y hace un ataque crítico");

            Daño = (int)((Ataca.Ataque() * 1.1) - Defiende.Defensa());
            
            if (Daño >= 100)
            {
                Daño = 25;
            }
            else
            {
                if (Daño < 10)
                {
                    Daño = 10;
                }
            }

            Defiende.Caracteristicas.Salud -= Daño;
        }
        else
        {
            Console.WriteLine($"{Defiende.Datos.Nombre} obtiene una bonificacion de defensa");

            Daño = (int)(Ataca.Ataque() - (Defiende.Defensa() * 1.1));

            if (Daño >= 100)
            {
                Daño = 25;
            }
            else
            {
                if (Daño < 10)
                {
                    Daño = 10;
                }
            }

            Defiende.Caracteristicas.Salud -= Daño;
        }
    }

    public async Task<Personaje> CombateTotal(Personaje Ataca, Personaje Defiende)
    {
        while (Ataca.Caracteristicas.Salud > 0 && Defiende.Caracteristicas.Salud > 0)
        {
            await TurnoBatalla(Ataca, Defiende);

            if (Defiende.Caracteristicas.Salud > 0)
            {
                await TurnoBatalla(Defiende, Ataca);
            }
        }

        if (Defiende.Caracteristicas.Salud > 0)
        {
            return Defiende;
        }
        else
        {
            return Ataca;
        }
    }
}