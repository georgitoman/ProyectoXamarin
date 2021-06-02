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

        public Command EliminarEquipo
        {
            get
            {
                return new Command(async () => {
                    await
                    this.Service.EliminarEquipoAsync(this.Equipo.IdEquipo);
                    MessagingCenter.Send(App.ServiceLocator.EquiposViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command ModificarEquipo
        {
            get
            {
                return new Command(async () => {
                    await this.Service.ModificarEquipo(this.Equipo.IdEquipo,
                        this.Equipo.Nombre, this.Equipo.Liga, this.Equipo.Foto);
                    MessagingCenter.Send(App.ServiceLocator.EquiposViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command InsertarEquipo
        {
            get
            {
                return new Command(async () => {
                    await this.Service.InsertarEquipo(this.Equipo.Nombre, this.Equipo.Liga, this.Equipo.Foto);
                    MessagingCenter.Send(App.ServiceLocator.EquiposViewModel, "RELOAD");
                    await Application.Current.MainPage.DisplayAlert("Alert", "Equipo insertado", "OK");
                });
            }
        }

    }
}
