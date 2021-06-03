using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoXamarin.ViewModels
{
    public class PartidoViewModel : ViewModelBase
    {
        private ServiceEquipos Service;

        public PartidoViewModel(ServiceEquipos service)
        {
            this.Service = service;

            if (this.Partido == null)
            {
                this.Partido = new Partidos();
            }
        }

        private Partidos _Partido;
        public Partidos Partido
        {
            get { return this._Partido; }
            set
            {
                this._Partido = value;
                OnPropertyChanged("Partido");
            }
        }
    }
}
