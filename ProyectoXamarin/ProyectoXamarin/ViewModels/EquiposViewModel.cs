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
    public class EquiposViewModel: ViewModelBase
    {
        private ServiceEquipos Service;

        public EquiposViewModel(ServiceEquipos service)
        {
            this.Service = service;

            Task.Run(async () =>
            {
                await this.CargarEquiposAsync();
            });
            MessagingCenter.Subscribe<EquiposViewModel>(this, "RELOAD",
                async (sender) =>
                {
                    await this.CargarEquiposAsync();
                });

        }

        private ObservableCollection<Equipo> _Equipos;
        public ObservableCollection<Equipo> Equipos
        {
            get { return this._Equipos; }
            set
            {
                this._Equipos = value;
                OnPropertyChanged("Equipos");
            }
        }

        public async Task CargarEquiposAsync()
        {
            List<Equipo> lista = await this.Service.GetEquiposAsync();
            this.Equipos = new ObservableCollection<Equipo>(lista);
        }

        public Command DetallesEquipo
        {
            get
            {
                return new Command(async (eq) =>
                {
                    Equipo equipo = eq as Equipo;
                    EquipoViewModel viewmodel =
                    App.ServiceLocator.EquipoViewModel;
                    viewmodel.Equipo = equipo;
                    DetailsEquipoView view =
                    new DetailsEquipoView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation
                    .PushModalAsync(view);
                });
            }
        }
    }
}