namespace SorteoGrupos;

using EspacioPersonaje;

public class Sorteo
{
    //Campos
    private List<Personaje> personajesSorteados = new List<Personaje>();
    private List<Personaje> combate = new List<Personaje>();
    private List<List<Personaje>> grupos = new List<List<Personaje>>();
    private Random random = new Random();

    //Propiedades
    public List<Personaje> PersonajesSorteados { get => personajesSorteados; set => personajesSorteados = value; }
    public List<Personaje> Combate { get => combate; set => combate = value; }
    public List<List<Personaje>> Grupos { get => grupos; set => grupos = value; }

    //Metodos
    public void SepararGrupos(List<Personaje> ListaSorteada)
    {
        //Obtengo la cantidad de elementos en la lista
        int tama = ListaSorteada.Count;
        int indice = 0;

        while (indice < tama)
        {
            List<Personaje> Combate = new List<Personaje>();

            for (int i = 0; i < 2; i++)
            {
                Combate.Add(ListaSorteada[indice]);
                    indice++;
            }

            Grupos.Add(Combate);
        }
    }

    public void SortearBatallas(List<Personaje> ListaCargada)
    {
        //Reordena de manera aleatoria la lista
        PersonajesSorteados = ListaCargada.OrderBy(x => random.Next()).ToList();

        SepararGrupos(PersonajesSorteados);
    }

}