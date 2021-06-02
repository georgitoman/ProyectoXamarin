using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Services;
using ProyectoXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            MessagingCenter.Subscribe<JugadoresViewModel>(this, "RELOAD",
                async (sender) =>
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

        public Command DetallesJugador
        {
            get
            {
                return new Command(async (jug) =>
                {
                    Jugador jugador = jug as Jugador;
                    JugadorViewModel viewmodel =
                    App.ServiceLocator.JugadorViewModel;
                    viewmodel.Jugador = jugador;
                    DetailsJugadorView view =
                    new DetailsJugadorView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation
                    .PushModalAsync(view);
                });
            }
        }

        public Command EditarJugador
        {
            get
            {
                return new Command(async (jug) => {
                    Jugador jugador = jug as Jugador;
                    JugadorViewModel viewmodel =
                    App.ServiceLocator.JugadorViewModel;
                    viewmodel.Jugador = jugador;
                    UpdateJugadorView view =
                    new UpdateJugadorView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation
                    .PushModalAsync(view);
                });
            }
        }
    }
}
