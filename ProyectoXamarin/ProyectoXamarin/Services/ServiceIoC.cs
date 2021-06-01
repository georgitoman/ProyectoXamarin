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
            builder.RegisterType<JugadoresViewModel>();
            builder.RegisterType<LigasViewModel>();
            builder.RegisterType<PartidosViewModel>();
            builder.RegisterType<PostsViewModel>();
            this.container = builder.Build();
        }

    }
}
