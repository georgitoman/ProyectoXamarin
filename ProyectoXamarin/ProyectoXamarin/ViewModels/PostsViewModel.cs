using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

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
    }
}
