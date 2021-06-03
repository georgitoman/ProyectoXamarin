using Newtonsoft.Json;
using ProyectoXamarin.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            return await this.CallApi<List<Jugador>>(request);
        }
        public async Task<Jugador> BuscarJugadorAsync(int id)
        {
            String request = "/api/Jugador/" + id;
            return await this.CallApi<Jugador>(request);
        }
        public async Task<List<Jugador>> BuscarJugadoresNickAsync(String nick)
        {
            String request = "/api/Jugador/JugadorNick/" + nick;
            return await this.CallApi<List<Jugador>>(request);
        }

        public async Task<List<Jugador>> PaginarJugadores(int pagina)
        {
            String request = "/api/Jugador/PaginarJugadores/" + pagina;
            return await this.CallApi<List<Jugador>>(request);
        }
        public async Task<List<Jugador>> GetJugadoresEquipoAsync(String nick, int equipo)
        {
            String request = "/api/Jugador/JugadorNickEquipo/" + nick + "/" + equipo;
            return await this.CallApi<List<Jugador>>(request);
        }

        public async Task<List<Jugador>> GetJugadoresEquipoAsync(int idequipo)
        {
            String request = "/api/Jugador/JugadoresEquipo/" + idequipo;
            return await this.CallApi<List<Jugador>>(request);
        }
        public async Task InsertarJugador(String nombre, String nick, int idequipo, String correo, String password, String foto)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "/api/Jugador";
                client.BaseAddress = this.Uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                Jugador jug = new Jugador();
                jug.IdJugador = 0;
                jug.Nombre = nombre;
                jug.Nick = nick;
                jug.IdEquipo = idequipo;
                jug.Funcion = "";
                jug.Correo = correo;
                jug.Password = password;
                jug.Foto = foto;
                String json = JsonConvert.SerializeObject(jug);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(request, content);
            }
        }
        public async Task ModificarJugador(int id, String nombre, String nick, int idequipo, String correo, String password, String foto)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "/api/Jugador";
                client.BaseAddress = this.Uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                Jugador jug = new Jugador();
                jug.IdJugador = id;
                jug.Nombre = nombre;
                jug.Nick = nick;
                jug.IdEquipo = idequipo;
                jug.Funcion = "";
                jug.Correo = correo;
                jug.Password = password;
                jug.Foto = foto;
                String json = JsonConvert.SerializeObject(jug);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }
        public async Task EliminarJugador(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "/api/Jugador/" + id;
                client.BaseAddress = this.Uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                await client.DeleteAsync(request);
            }
        }
        public async Task<Jugador> ExisteJugador(String nick, String password)
        {
            String request = "/api/Jugador/ExisteJugador/" + nick + "/" + password;
            return await this.CallApi<Jugador>(request);
        }
        #endregion


        #region Equipos
        public async Task<List<Equipo>> GetEquiposAsync()
        {
            String request = "/api/Equipo";
            return await this.CallApi<List<Equipo>>(request);
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


        public async Task InsertarEquipo(String nombre, int liga, String foto)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "/api/Equipo";
                client.BaseAddress = this.Uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                Equipo eq = new Equipo();
                eq.IdEquipo = 0;
                eq.Nombre = nombre;
                eq.Liga = liga;
                eq.Foto = foto;
                String json = JsonConvert.SerializeObject(eq);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(request, content);
            }
        }
        public async Task ModificarEquipo(int id, String nombre, int liga, String foto)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "/api/Equipo";
                client.BaseAddress = this.Uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                Equipo eq = new Equipo();
                eq.IdEquipo = id;
                eq.Nombre = nombre;
                eq.Liga = liga;
                eq.Foto = foto;
                String json = JsonConvert.SerializeObject(eq);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }
        public async Task EliminarEquipoAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "/api/Equipo/" + id;
                client.BaseAddress = this.Uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                await client.DeleteAsync(request);
            }
        }
        #endregion


        #region Partidos

        public async Task<List<Partidos>> GetPartidosAsync()
        {
            String request = "/api/PartidosNombre";
            return await this.CallApi<List<Partidos>>(request);
        }
        public async Task<Partidos> BuscarPartidosAsync(int id)
        {
            String request = "/api/PartidosNombre/" + id;
            return await this.CallApi<Partidos>(request);
        }
        public async Task<List<Partidos>> PaginarPartidosAsync(int pagina)
        {
            String request = "/api/Partidos/PaginarPartidos/" + pagina;
            return await this.CallApi<List<Partidos>>(request);
        }
        public async Task<List<Partidos>> BuscarPartidosEquiposAsync(int idequipo)
        {
            String request = "/api/Partidos/PartidosEquipo/" + idequipo;
            return await this.CallApi<List<Partidos>>(request);
        }

        #endregion


        #region Ligas
        public async Task<List<Liga>> GetLigasAsync()
        {
            String request = "/api/Liga";
            return await this.CallApi<List<Liga>>(request);
        }
        public async Task<Liga> BuscarLigaAsync(int id)
        {
            String request = "/api/Equipo/" + id;
            return await this.CallApi<Liga>(request);
        }
        public async Task<Liga> BuscarLigaNombreAsync(String nombre)
        {
            String request = "/api/Liga/BuscarLigasNombre/" + nombre;
            return await this.CallApi<Liga>(request);
        }
        public async Task<List<Liga>> BuscarEquiposLigasAsync(String nombre)
        {
            String request = "/api/Liga/BuscarLigasNombre/" + nombre;
            return await this.CallApi<List<Liga>>(request);
        }

        public async Task InsertarLigaAsync(String nombre, String descripcion)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "/api/Liga";
                client.BaseAddress = this.Uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                Liga lig = new Liga();
                lig.IdLiga = 0;
                lig.Nombre = nombre;
                lig.Descripcion = descripcion;
                String json = JsonConvert.SerializeObject(lig);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(request, content);
            }
        }
        public async Task ModificarLigaAsync(int id, String nombre, String descripcion)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "/api/Liga";
                client.BaseAddress = this.Uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                Liga lig = new Liga();
                lig.IdLiga = id;
                lig.Nombre = nombre;
                lig.Descripcion = descripcion;
                String json = JsonConvert.SerializeObject(lig);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }
        public async Task EliminarLigaAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "/api/Liga/" + id;
                client.BaseAddress = this.Uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                await client.DeleteAsync(request);
            }
        }

        #endregion
    }
}
