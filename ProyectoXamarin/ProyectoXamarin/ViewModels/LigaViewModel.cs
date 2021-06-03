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
    public class LigaViewModel : ViewModelBase
    {
        private ServiceEquipos Service;

        public LigaViewModel(ServiceEquipos service)
        {
            this.Service = service;

            if (this.Liga == null)
            {
                this.Liga = new Liga();
            }


            Task.Run(async () =>
            {
                await this.CargarEquiposAsync();
            });
        }

        private Liga _Liga;
        public Liga Liga
        {
            get { return this._Liga; }
            set
            {
                this._Liga = value;
                OnPropertyChanged("Liga");
            }
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
            List<Equipo> equipos = await this.Service.BuscarEquiposLigasAsync(this.Liga.IdLiga);
            ObservableCollection<Equipo> aux = new ObservableCollection<Equipo>();

            foreach (Equipo eq in equipos)
            {
                aux.Add(eq);
            }

            this.Equipos = aux;
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