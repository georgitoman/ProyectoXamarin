using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoXamarin.Models
{
    public class Posts
    {
        [JsonProperty("idPost")]
        public int IdPost { get; set; }
        [JsonProperty("titulo")]
        public String Titulo { get; set; }
        [JsonProperty("asunto")]
        public String Asunto { get; set; }
        [JsonProperty("descripcion")]
        public String Descripcion { get; set; }
        [JsonProperty("idPadre")]
        public int IdPadre { get; set; }
        [JsonProperty("idUsuario")]
        public int IdUsuario { get; set; }
    }
}