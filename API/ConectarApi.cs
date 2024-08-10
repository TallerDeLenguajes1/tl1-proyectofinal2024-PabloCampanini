namespace ConectarApi;

using System.Text.Json;
using EspacioDados;


public class TirarDados
{
    private static readonly HttpClient client = new HttpClient();
    private Random random = new Random();
    public async Task<Dados> GetDados(int CantidadDados, int TamanioDado)
    {
        var url = $"https://rolz.org/api/?{CantidadDados}d{TamanioDado}.json";

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Dados dado = JsonSerializer.Deserialize<Dados>(responseBody);
            return dado;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error en la solicitud: {e.Message}");

            Dados dado = new Dados();

            int ResultadoFinal = 0;

            List<string> Valores = new List<string>();

            for (int i = 0; i < CantidadDados; i++)
            {
                int Tirada = random.Next(1, TamanioDado + 1);

                ResultadoFinal += Tirada;

                Valores.Add(Tirada.ToString());
            }

            dado.Result = ResultadoFinal;
            dado.Details = string.Join(" + ", Valores);


            return dado;
        }
    }
}