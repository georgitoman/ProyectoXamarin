using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoXamarin.Models
{
    public class Partidos
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("equipo1")]
        public String Equipo1 { get; set; }
        [JsonProperty("equipo2")]
        public String Equipo2 { get; set; }
        [JsonProperty("resultadoEquipo1")]
        public int ResultadoEquipo1 { get; set; }
        [JsonProperty("resultadoEquipo2")]
        public int ResultadoEquipo2 { get; set; }
        [JsonProperty("fecha")]
        public String Fecha { get; set; }
    }
}
