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
    public class PartidosViewModel : ViewModelBase
    {
        private ServiceEquipos Service;

        public PartidosViewModel(ServiceEquipos service)
        {
            this.Service = service;

            Task.Run(async () =>
            {
                await this.CargarPartidosAsync();
            });
            MessagingCenter.Subscribe<PartidosViewModel>(this, "RELOAD",
                async (sender) =>
                {
                    await this.CargarPartidosAsync();
                });
        }

        private ObservableCollection<Partidos> _Partidos;
        public ObservableCollection<Partidos> Partidos
        {
            get { return this._Partidos; }
            set
            {
                this._Partidos = value;
                OnPropertyChanged("Partidos");
            }
        }

        public async Task CargarPartidosAsync()
        {
            List<Partidos> lista = await this.Service.GetPartidosAsync();
            this.Partidos = new ObservableCollection<Partidos>(lista);
        }

        public Command DetallesPartido
        {
            get
            {
                return new Command(async (par) =>
                {
                    Partidos partido = par as Partidos;
                    PartidoViewModel viewmodel =
                    App.ServiceLocator.PartidoViewModel;
                    viewmodel.Partido = partido;
                    DetailsPartidoView view =
                    new DetailsPartidoView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation
                    .PushModalAsync(view);
                });
            }
        }

        public Command EditarPartido
        {
            get
            {
                return new Command(async (par) => {
                    Partidos partido = par as Partidos;
                    PartidoViewModel viewmodel =
                    App.ServiceLocator.PartidoViewModel;
                    viewmodel.Partido = partido;
                    UpdatePartidoView view =
                    new UpdatePartidoView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation
                    .PushModalAsync(view);
                });
            }
        }
    }
}
