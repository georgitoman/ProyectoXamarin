using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Services;
using ProyectoXamarin.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoXamarin.ViewModels
{
    public class EquipoViewModel : ViewModelBase
    {
        private ServiceEquipos Service;

        public EquipoViewModel(ServiceEquipos service)
        {
            this.Service = service;

            if (this.Equipo == null)
            {
                this.Equipo = new Equipo();
            }

            Task.Run(async () =>
            {
                await this.CargarJugadoresAsync();
            });
        }

        private Equipo _Equipo;
        public Equipo Equipo
        {
            get { return this._Equipo; }
            set
            {
                this._Equipo = value;
                OnPropertyChanged("Equipo");
            }
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
            List<Jugador> jugadores = await this.Service.GetJugadoresEquipoAsync(this.Equipo.IdEquipo);
            ObservableCollection<Jugador> aux = new ObservableCollection<Jugador>();

            foreach (Jugador jug in jugadores)
            {
                aux.Add(jug);
            }

            this.Jugadores = aux;
        }

        public Command DetallesJugador
        {
            get
            {
                return new Command(async (jug) =>
                {
                    Jugador jugador = jug as Jugador;
                    JugadorViewModel viewmodel = App.ServiceLocator.JugadorViewModel;
                    viewmodel.Jugador = jugador;
                    DetailsJugadorView view = new DetailsJugadorView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }

    }
}
