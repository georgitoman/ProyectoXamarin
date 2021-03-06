using Newtonsoft.Json;
using System;

namespace ProyectoXamarin.Models
{
    public class Equipo
    {
        [JsonProperty("idEquipo")]
        public int IdEquipo { set; get; }
        [JsonProperty("nombre")]
        public String Nombre { set; get; }
        [JsonProperty("liga")]
        public int Liga { get; set; }
        [JsonProperty("foto")]
        public String Foto { get; set; }
    }
}
