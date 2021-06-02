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

        public Command EliminarJugador
        {
            get
            {
                return new Command(async () => {
                    await
                    this.Service.EliminarJugador(this.Jugador.IdJugador);
                    MessagingCenter.Send(App.ServiceLocator.JugadoresViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command ModificarJugador
        {
            get
            {
                return new Command(async () => {
                    await this.Service.ModificarJugador(this.Jugador.IdJugador,
                        this.Jugador.Nombre, this.Jugador.Nick, this.Jugador.IdEquipo,
                        this.Jugador.Correo, this.Jugador.Password, this.Jugador.Foto);
                    MessagingCenter.Send(App.ServiceLocator.JugadoresViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command InsertarJugador
        {
            get
            {
                return new Command(async () => {
                    await this.Service.InsertarJugador(this.Jugador.Nombre,
                        this.Jugador.Nick, this.Jugador.IdEquipo, this.Jugador.Correo,
                        this.Jugador.Password, this.Jugador.Foto);
                    MessagingCenter.Send(App.ServiceLocator.JugadoresViewModel, "RELOAD");
                    await Application.Current.MainPage.DisplayAlert("Alert", "Jugador insertado", "OK");
                });
            }
        }

    }
}
