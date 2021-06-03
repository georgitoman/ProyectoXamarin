using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}