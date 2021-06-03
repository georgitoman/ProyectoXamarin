using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoXamarin.ViewModels
{
    public class JugadorViewModel : ViewModelBase
    {
        private ServiceEquipos Service;

        public JugadorViewModel(ServiceEquipos service)
        {
            this.Service = service;

            if (this.Jugador == null)
            {
                this.Jugador = new Jugador();
            }
        }

        private Jugador _Jugador;
        public Jugador Jugador
        {
            get { return this._Jugador; }
            set
            {
                this._Jugador = value;
                OnPropertyChanged("Jugador");
            }
        }
    }
}
