# Torneo de Eldoria

## Descripción del Proyecto

**Torneo de Eldoria** es un juego de simulación de combate por turnos, ambientado en un torneo ficticio. Los personajes luchan por obtener el trono en un combate a muerte. El juego incluye una amplia variedad de personajes, que se enfrentaran para ver quien gobernara la vasta tierra de Eldoria.
## Características Principales

- **Generación de Personajes:** Los personajes se crean a partir de uno que elija el usuario y otros que se generan de manera aleatoria con datos preestablecidos, velocidad, armadura y demas es creado de manera aleatoria para generar diferentes dificultades a la hs de combatir.
- **Sistema de Combate:** Los combates se realizan por turnos, donde una tiradas de dados proporcionada por una API decide quien ataca primero y quien recibe una bonificacion en daño o defensa.
- **Historial de Ganadores:** Se guarda un historial de ganadores, con el nombre, edad y raza del ultimo gobernante.
- **Persistencia de Partidas:** Las partidas se pueden guardar y cargar si se cierra el juego permitiendo continuar, ademas podemos cargar los personajes de la partida anterior si se desea.

## Tecnologías Utilizadas

- **Lenguaje:** C#
- **Desarrollo Asíncrono:** El juego utiliza tareas asíncronas para operaciones de combates.
- **Persistencia de Datos:** JSON se utiliza para guardar y leer datos persistentes, como los ganadores del torneo y las partidas guardadas.
- **Manipulación de la Consola:** Se emplea la consola para la interacción del usuario, con personalización de colores y centrado de texto para mejorar la experiencia visual.

## API

**Rolz.org API** es la API que utilizo, esta permite la simulacion de tiradas de n dados iguales de m caras, donde nosotros podemos solicitar que tipo y cuantos dados necesitamos, ademas, permite obtener los resultados en varios formatos como ser JSON, texto plano o SML. Para ello en la solicitud indicamos la cantidad y el tipo de dado, por ejemplo, si queremos usar 2 dados de 20 caras ponemos la siguiente forma:

- **URL de la API:** "https://rolz.org/api/?<tus tiradas>" , donde <tus tiradas> debe cargarse por ejemplo 2d20.json.

Indicando "CANTIDAD + d + CARAS. extension". En este proyecto uso 1 dado de 20 caras para cada solicitud por lo que el URL quedaria de la siguiente manera: 

- **URL de la API en el proyecto:** "https://rolz.org/api/?1d20.json"

La API devuelve la siguiente estructura al solicitarla con extension .json:
```
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
```

De aqui podemos obtener el total de la tirada ubicado en result, o usar una descripcion mas detallada en details donde tenemos en formato string la suma de los n valores que dieron los n dados. 

## Archivos Json

El programa utiliza archivos Json para almacenar y utilizar datos y caracterisiticas, ademas de encargarse del cargado y lectura del historial de ganadores.