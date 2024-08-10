namespace EspacioTorneo;

using EspacioPersonaje;
using EspacioPelea;
using SorteoGrupos;
using EspacioDados;
using ConectarApi;

public class Torneo
{
    //Campos
    private List<Personaje> siguienteRonda = new List<Personaje>();
    private TirarDados tirarDados = new TirarDados();

    //Propiedades
    public List<Personaje> SiguienteRonda { get => siguienteRonda; set => siguienteRonda = value; }
    public TirarDados TirarDados { get => tirarDados; set => tirarDados = value; }

    //Metodos
    public async Task Ronda1(List<Personaje> Participantes)
    {
        //Sorteo de batallas
        Sorteo sorteo = new Sorteo();
        Batalla batalla = new Batalla();

        sorteo.SortearBatallas(Participantes);

        int Indice = 0;

        while (sorteo.Grupos.Count > Indice)
        {
            List<Personaje> GrupoPelea = sorteo.Grupos[Indice];

            //Sorteo quien ataca primero
            Dados Dado = await TirarDados.GetDados(1, 20);

            Console.WriteLine($"Combate entre {GrupoPelea[0].Datos.Nombre} y {GrupoPelea[1].Datos.Nombre}");

            if (Dado.Result % 2 == 0)
            {
                Personaje GanadorBatalla = await batalla.CombateTotal(GrupoPelea[0], GrupoPelea[1]);
                SiguienteRonda.Add(GanadorBatalla);
            }
            else
            {
                Personaje GanadorBatalla = await batalla.CombateTotal(GrupoPelea[1], GrupoPelea[0]);
                SiguienteRonda.Add(GanadorBatalla);
            }

            Indice++;
        }
    }

    public async Task RondaN()
    {
        Batalla batalla = new Batalla();

        while (SiguienteRonda.Count > 1)
        {
            List<Personaje> GanadoresRonda = new List<Personaje>();

            int CantidadCombates = SiguienteRonda.Count / 2;

            for (int i = 0; i < CantidadCombates; i++)
            {
                //Sorteo quien ataca primero
                Dados Dado = await TirarDados.GetDados(1, 20);

                Console.WriteLine($"Combate entre {SiguienteRonda[i * 2].Datos.Nombre} y {SiguienteRonda[(i * 2) + 1].Datos.Nombre}");

                if (Dado.Result % 2 == 0)
                {
                    Personaje GanadorBatalla = await batalla.CombateTotal(SiguienteRonda[i * 2], SiguienteRonda[(i * 2) + 1]);
                    GanadoresRonda.Add(GanadorBatalla);
                }
                else
                {
                    Personaje GanadorBatalla = await batalla.CombateTotal(SiguienteRonda[(i * 2) + 1], SiguienteRonda[i * 2]);
                    GanadoresRonda.Add(GanadorBatalla);
                }

            }

            SiguienteRonda = GanadoresRonda;
        }
    }

    public async Task<Personaje> RealizarTorneo(List<Personaje> Participantes)
    {
        //Realizamos sorteos de los grupos de la primer ronda y las batallas de la primer ronda
        await Ronda1(Participantes);

        await RondaN();

        //SiguienteRonda sale con un solo personaje cargado
        return SiguienteRonda[0];
    }
}