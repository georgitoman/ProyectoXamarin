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
    }
}
