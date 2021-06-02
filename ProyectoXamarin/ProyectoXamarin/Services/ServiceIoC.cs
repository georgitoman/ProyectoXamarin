using Autofac;
using ProyectoXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoXamarin.Services
{
    public class ServiceIoC
    {
        private IContainer container;

        public ServiceIoC()
        {
            this.RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<ServiceEquipos>();
            builder.RegisterType<EquiposViewModel>();
            builder.RegisterType<EquipoViewModel>();
            builder.RegisterType<JugadoresViewModel>();
            builder.RegisterType<JugadorViewModel>();
            builder.RegisterType<LigasViewModel>();
            builder.RegisterType<LigaViewModel>();
            builder.RegisterType<PartidosViewModel>();
            builder.RegisterType<PartidoViewModel>();
            builder.RegisterType<PostsViewModel>();
            builder.RegisterType<PostViewModel>();
            this.container = builder.Build();
        }

        public EquiposViewModel EquiposViewModel
        {
            get
            {
                return this.container.Resolve<EquiposViewModel>();
            }
        }

        public JugadoresViewModel JugadoresViewModel
        {
            get
            {
                return this.container.Resolve<JugadoresViewModel>();
            }
        }

        public LigasViewModel LigasViewModel
        {
            get
            {
                return this.container.Resolve<LigasViewModel>();
            }
        }

        public PartidosViewModel PartidosViewModel
        {
            get
            {
                return this.container.Resolve<PartidosViewModel>();
            }
        }

        public PostsViewModel PostsViewModel
        {
            get
            {
                return this.container.Resolve<PostsViewModel>();
            }
        }

        public EquipoViewModel EquipoViewModel
        {
            get
            {
                return this.container.Resolve<EquipoViewModel>();
            }
        }

        public JugadorViewModel JugadorViewModel
        {
            get
            {
                return this.container.Resolve<JugadorViewModel>();
            }
        }

        public LigaViewModel LigaViewModel
        {
            get
            {
                return this.container.Resolve<LigaViewModel>();
            }
        }

        public PartidoViewModel PartidoViewModel
        {
            get
            {
                return this.container.Resolve<PartidoViewModel>();
            }
        }

        public PostViewModel PostViewModel
        {
            get
            {
                return this.container.Resolve<PostViewModel>();
            }
        }

    }
}
