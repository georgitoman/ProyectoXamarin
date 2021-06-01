using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoXamarin.ViewModels
{
    public class JugadoresViewModel:ViewModelBase
    {
        private ServiceEquipos Service;

        public JugadoresViewModel(ServiceEquipos service)
        {
            this.Service = service;

            Task.Run(async () =>
            {
                await this.CargarJugadoresAsync();
            });
        }

        private ObservableCollection<Jugador> _Jugadores;
        public ObservableCollection<Jugador> Jugadores
        {
            get { return this._Jugadores; }
            set
            {
                this._Jugadores = value;
                OnPropertyChanged("Jugadores");
            }
        }

        public async Task CargarJugadoresAsync()
        {
            List<Jugador> lista = await this.Service.GetJugadoresAsync();
            this.Jugadores = new ObservableCollection<Jugador>(lista);
        }
    }
}
