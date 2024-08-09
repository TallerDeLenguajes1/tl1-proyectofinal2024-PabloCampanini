namespace EspacioTorneo;

using EspacioPersonaje;
using EspacioPelea;
using SorteoGrupos;

public class Torneo
{
    //Campos
    private List<Personaje> siguienteRonda = new List<Personaje>();

    //Propiedades
    public List<Personaje> SiguienteRonda { get => siguienteRonda; set => siguienteRonda = value; }

    //Metodos
    public void Ronda1(List<Personaje> Participantes)
    {
        //Sorteo de batallas
        Sorteo sorteo = new Sorteo();
        Batalla batalla = new Batalla();

        sorteo.SortearBatallas(Participantes);

        int Indice = 0;

        while (sorteo.Grupos.Count > Indice)
        {
            List<Personaje> GrupoPelea = sorteo.Grupos[Indice];

            //Sorteo quien empieza atacando

            Personaje GanadorBatalla = batalla.CombateTotal(GrupoPelea[0], GrupoPelea[1]);

            SiguienteRonda.Add(GanadorBatalla);

            Indice++;
        }
    }

    public void RondaN()
    {
        Batalla batalla = new Batalla();

        while (SiguienteRonda.Count > 1)
        {
            List<Personaje> GanadoresRonda = new List<Personaje>();

            int CantidadCombates = SiguienteRonda.Count / 2;

            for (int i = 0; i < CantidadCombates; i++)
            {
                Personaje GanadorBatalla = batalla.CombateTotal(SiguienteRonda[i * 2], SiguienteRonda[(i * 2) + 1]);

                GanadoresRonda.Add(GanadorBatalla);
            }

            SiguienteRonda = GanadoresRonda;
        }
    }

    public Personaje RealizarTorneo(List<Personaje> Participantes)
    {
        //Realizamos sorteos de los grupos de la primer ronda y las batallas de la primer ronda
        Ronda1(Participantes);

        RondaN();

        //SiguienteRonda sale con un solo personaje cargado
        return SiguienteRonda[0];
    }
}