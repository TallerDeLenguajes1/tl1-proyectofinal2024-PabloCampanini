namespace JsonHelper;

using System.Text.Json;
public class HelperDeJson
{
    // Leer archivo de texto y devolver su contenido
    public string AbrirArchivoTexto(string nombreArchivo)
    {
        string documento;
        using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
        {
            using (var strReader = new StreamReader(archivoOpen))
            {
                documento = strReader.ReadToEnd();
                archivoOpen.Close();
            }
        }
        return documento;
    }

    // Guardar contenido de texto en un archivo
    public void GuardarArchivoTexto(string nombreArchivo, string datos)
    {
        using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
        {
            using (var strWriter = new StreamWriter(archivo))
            {
                strWriter.WriteLine("{0}", datos);
                strWriter.Close();
            }
        }
    }

    // Guardar un objeto en formato JSON en un archivo de texto
    public void GuardarArchivoJson<T>(string nombreArchivo, T objeto)
    {
        string datosJson = JsonSerializer.Serialize(objeto, new JsonSerializerOptions { WriteIndented = true });
        GuardarArchivoTexto(nombreArchivo, datosJson);
    }

    // Leer un archivo de texto y deserializarlo a un objeto
    public T AbrirArchivoJson<T>(string nombreArchivo)
    {
        string datosJson = AbrirArchivoTexto(nombreArchivo);
        return JsonSerializer.Deserialize<T>(datosJson);
    }
}