using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoXamarin.ViewModels
{
    public class PostViewModel : ViewModelBase
    {
        private ServiceEquipos Service;

        public PostViewModel(ServiceEquipos service)
        {
            this.Service = service;

            if (this.Post == null)
            {
                this.Post = new Posts();
            }
        }

        private Posts _Post;
        public Posts Post
        {
            get { return this._Post; }
            set
            {
                this._Post = value;
                OnPropertyChanged("Post");
            }
        }

        public Command EliminarPost
        {
            get
            {
                return new Command(async () =>
                {
                    await
                    this.Service.EliminarPost(this.Post.IdPost);
                    MessagingCenter.Send(App.ServiceLocator.PostsViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command ModificarPost
        {
            get
            {
                return new Command(async () =>
                {
                    await this.Service.ModificarPost(this.Post.IdPost,
                        this.Post.Titulo, this.Post.Descripcion);
                    MessagingCenter.Send(App.ServiceLocator.PostsViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command InsertarPost
        {
            get
            {
                return new Command(async () =>
                {
                    await this.Service.InsertarPost(this.Post.Titulo, this.Post.Descripcion);
                    MessagingCenter.Send(App.ServiceLocator.PostsViewModel, "RELOAD");
                    await Application.Current.MainPage.DisplayAlert("Alert", "Post insertado", "OK");
                });
            }
        }
    }
}
