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

        public Command EliminarLiga
        {
            get
            {
                return new Command(async () =>
                {
                    await
                    this.Service.EliminarLigaAsync(this.Liga.IdLiga);
                    MessagingCenter.Send(App.ServiceLocator.LigasViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command ModificarLiga
        {
            get
            {
                return new Command(async () =>
                {
                    await this.Service.ModificarLigaAsync(this.Liga.IdLiga,
                        this.Liga.Nombre, this.Liga.Descripcion);
                    MessagingCenter.Send(App.ServiceLocator.LigasViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command InsertarLiga
        {
            get
            {
                return new Command(async () =>
                {
                    await this.Service.InsertarLigaAsync(this.Liga.Nombre, this.Liga.Descripcion);
                    MessagingCenter.Send(App.ServiceLocator.LigasViewModel, "RELOAD");
                    await Application.Current.MainPage.DisplayAlert("Alert", "Liga insertada", "OK");
                });
            }
        }
    }
}