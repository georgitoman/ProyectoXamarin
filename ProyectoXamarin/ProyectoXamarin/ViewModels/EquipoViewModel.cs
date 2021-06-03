using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoXamarin.ViewModels
{
    public class EquipoViewModel : ViewModelBase
    {
        private ServiceEquipos Service;

        public EquipoViewModel(ServiceEquipos service)
        {
            this.Service = service;

            if(this.Equipo == null)
            {
                this.Equipo = new Equipo();
            }
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

    }
}
