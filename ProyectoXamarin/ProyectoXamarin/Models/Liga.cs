using Newtonsoft.Json;
using System;

namespace ProyectoXamarin.Models
{
    public class Liga
    {
        [JsonProperty("idLiga")]
        public int IdLiga { get; set; }
        [JsonProperty("nombre")]
        public String Nombre { get; set; }
        [JsonProperty("descripcion")]
        public String Descripcion { get; set; }
    }
}
