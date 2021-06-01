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
    public class LigasViewModel : ViewModelBase
    {
        private ServiceEquipos Service;

        public LigasViewModel(ServiceEquipos service)
        {
            this.Service = service;

            Task.Run(async () =>
            {
                await this.CargarLigasAsync();
            });
        }

        private ObservableCollection<Liga> _Ligas;
        public ObservableCollection<Liga> Ligas
        {
            get { return this._Ligas; }
            set
            {
                this._Ligas = value;
                OnPropertyChanged("Ligas");
            }
        }

        public async Task CargarLigasAsync()
        {
            List<Liga> lista = await this.Service.GetLigasAsync();
            this.Ligas = new ObservableCollection<Liga>(lista);
        }
    }
}
