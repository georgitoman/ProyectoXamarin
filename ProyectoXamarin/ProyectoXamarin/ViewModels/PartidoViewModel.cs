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

        public Command ModificarPartido
        {
            get
            {
                return new Command(async () =>
                {
                    await this.Service.ModificarPartidos(this.Partido.Id, this.Partido.Equipo1,
                        this.Partido.Equipo2, this.Partido.ResultadoEquipo1, this.Partido.ResultadoEquipo2,
                        this.Partido.Fecha);
                    MessagingCenter.Send(App.ServiceLocator.PartidosViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command InsertarPartido
        {
            get
            {
                return new Command(async () =>
                {
                    await this.Service.InsertarPartidos(this.Partido.Equipo1, this.Partido.Equipo2,
                        this.Partido.ResultadoEquipo1, this.Partido.ResultadoEquipo2, this.Partido.Fecha);
                    MessagingCenter.Send(App.ServiceLocator.PartidosViewModel, "RELOAD");
                    await Application.Current.MainPage.DisplayAlert("Alert", "Partido insertado", "OK");
                });
            }
        }
    }
}
