using Newtonsoft.Json;
using System;

namespace ProyectoXamarin.Models
{
    public class Jugador
    {
        [JsonProperty("idJugador")]
        public int IdJugador { get; set; }
        [JsonProperty("nombre")]
        public String Nombre { get; set; }
        [JsonProperty("nick")]
        public String Nick { get; set; }
        [JsonProperty("funcion")]
        public String Funcion { get; set; }
        [JsonProperty("idEquipo")]
        public int IdEquipo { get; set; }
        [JsonProperty("correo")]
        public String Correo { get; set; }
        [JsonProperty("password")]
        public String Password { get; set; }
        [JsonProperty("foto")]
        public String Foto { get; set; }
    }
}
