using Newtonsoft.Json;
using ProyectoXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProyectoXamarin.Services
{
    public class ServiceEquipos
    {
        private Uri Uriapi;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceEquipos()
        {
            this.Uriapi = new Uri("https://apiproyectoxamarin.azurewebsites.net");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApi<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.Uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    T data = JsonConvert.DeserializeObject<T>(json);
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        #region Jugador

        public async Task<List<Jugador>> GetJugadoresAsync()
        {
            String request = "/api/Jugador";
            List<Jugador> Jugadores = await this.CallApi<List<Jugador>>(request);
            return Jugadores.Where(x => x.IdJugador > 0).ToList();
        }
        public async Task<Jugador> BuscarJugadorAsync(int id)
        {
            String request = "/api/Jugador/" + id;
            return await this.CallApi<Jugador>(request);
        }

        public async Task<List<Jugador>> GetJugadoresEquipoAsync(int idequipo)
        {
            String request = "/api/Jugador/JugadoresEquipo/" + idequipo;
            return await this.CallApi<List<Jugador>>(request);
        }

        #endregion


        #region Equipos
        public async Task<List<Equipo>> GetEquiposAsync()
        {
            String request = "/api/Equipo";
            List<Equipo> equipos = await this.CallApi<List<Equipo>>(request);
            return equipos.Where(x => x.IdEquipo > 0).ToList();
        }
        public async Task<Equipo> BuscarEquipoAsync(int id)
        {
            String request = "/api/Equipo/" + id;
            return await this.CallApi<Equipo>(request);
        }
        public async Task<List<Equipo>> BuscarEquiposLigasAsync(int idliga)
        {
            String request = "/api/Equipo/BuscarEquiposLiga/" + idliga;
            return await this.CallApi<List<Equipo>>(request);
        }

        #endregion


        #region Partidos

        public async Task<List<Partidos>> GetPartidosAsync()
        {
            String request = "/api/PartidosNombre";
            return await this.CallApi<List<Partidos>>(request);
        }

        #endregion


        #region Ligas
        public async Task<List<Liga>> GetLigasAsync()
        {
            String request = "/api/Liga";
            List<Liga> ligas = await this.CallApi<List<Liga>>(request);
            return ligas.Where(x => x.IdLiga > 0).ToList();
        }
        public async Task<Liga> BuscarLigaAsync(int id)
        {
            String request = "/api/Equipo/" + id;
            return await this.CallApi<Liga>(request);
        }
        public async Task<List<Liga>> BuscarEquiposLigasAsync(String nombre)
        {
            String request = "/api/Liga/BuscarLigasNombre/" + nombre;
            return await this.CallApi<List<Liga>>(request);
        }

        #endregion
    }
}
