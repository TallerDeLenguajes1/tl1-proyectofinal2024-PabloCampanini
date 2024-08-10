namespace MostrarDatos
{
    using EspacioPersonaje;

    public class MostrarPersonaje
    {
        public void MostrarDatosPersonaje(Personaje personaje)
        {
            int anchoColumna = 30; // Ajusta el ancho según sea necesario

            Console.ForegroundColor = ConsoleColor.Green;

            // Línea superior del recuadro
            Console.WriteLine("╔" + new string('═', anchoColumna + 2) + "╦" + new string('═', anchoColumna + 2) + "╗");

            // Imprimir filas
            ImprimirFila("Nombre", personaje.Datos.Nombre, anchoColumna);
            ImprimirFila("Apodo", personaje.Datos.Apodo, anchoColumna);
            ImprimirFila("Fecha de Nacimiento", personaje.Datos.FechaDeNacimiento.ToString("dd/MM/yyyy"), anchoColumna);
            ImprimirFila("Edad", personaje.Datos.Edad.ToString(), anchoColumna);
            ImprimirFila("Raza", personaje.Datos.Raza, anchoColumna);
            ImprimirFila("Velocidad", personaje.Caracteristicas.Velocidad.ToString(), anchoColumna);
            ImprimirFila("Destreza", personaje.Caracteristicas.Destreza.ToString(), anchoColumna);
            ImprimirFila("Fuerza", personaje.Caracteristicas.Fuerza.ToString(), anchoColumna);
            ImprimirFila("Nivel", personaje.Caracteristicas.Nivel.ToString(), anchoColumna);
            ImprimirFila("Armadura", personaje.Caracteristicas.Armadura.ToString(), anchoColumna);
            ImprimirFila("Salud", personaje.Caracteristicas.Salud.ToString(), anchoColumna);

            // Línea inferior del recuadro
            Console.WriteLine("╚" + new string('═', anchoColumna + 2) + "╩" + new string('═', anchoColumna + 2) + "╝");

            Console.ResetColor();
        }

        private void ImprimirFila(string etiqueta, string valor, int anchoColumna)
        {
            // Añade espacios adicionales para el borde
            string fila = "║ " + etiqueta.PadRight(anchoColumna) + " ║ " + valor.PadRight(anchoColumna) + " ║";
            Console.WriteLine(fila);
        }
    }
}