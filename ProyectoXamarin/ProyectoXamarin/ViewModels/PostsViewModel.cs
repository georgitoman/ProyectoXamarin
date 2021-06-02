using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Services;
using ProyectoXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoXamarin.ViewModels
{
    public class PostsViewModel : ViewModelBase
    {
        private ServiceEquipos Service;

        public PostsViewModel(ServiceEquipos service)
        {
            this.Service = service;

            Task.Run(async () =>
            {
                await this.CargarPostsAsync();
            });
            MessagingCenter.Subscribe<PostsViewModel>(this, "RELOAD",
                async (sender) =>
                {
                    await this.CargarPostsAsync();
                });
        }

        private ObservableCollection<Posts> _Posts;
        public ObservableCollection<Posts> Posts
        {
            get { return this._Posts; }
            set
            {
                this._Posts = value;
                OnPropertyChanged("Posts");
            }
        }

        public async Task CargarPostsAsync()
        {
            List<Posts> lista = await this.Service.GetPostsAsync();
            this.Posts = new ObservableCollection<Posts>(lista);
        }

        public Command DetallesPost
        {
            get
            {
                return new Command(async (pos) =>
                {
                    Posts post = pos as Posts;
                    PostViewModel viewmodel =
                    App.ServiceLocator.PostViewModel;
                    viewmodel.Post = post;
                    DetailsPostView view =
                    new DetailsPostView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation
                    .PushModalAsync(view);
                });
            }
        }

        public Command EditarPost
        {
            get
            {
                return new Command(async (Post) => {
                    Posts post = Post as Posts;
                    PostViewModel viewmodel =
                    App.ServiceLocator.PostViewModel;
                    viewmodel.Post = post;
                    UpdatePostView view =
                    new UpdatePostView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation
                    .PushModalAsync(view);
                });
            }
        }
    }
}
