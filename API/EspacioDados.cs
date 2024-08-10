namespace EspacioDados;

using System.Text.Json.Serialization;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class Dados
{
    [JsonPropertyName("input")]
    public string Input { get; set; }

    [JsonPropertyName("result")]
    public int Result { get; set; }

    [JsonPropertyName("details")]
    public string Details { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("illustration")]
    public string Illustration { get; set; }

    [JsonPropertyName("timestamp")]
    public int Timestamp { get; set; }

    [JsonPropertyName("x")]
    public int X { get; set; }
}