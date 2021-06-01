using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
