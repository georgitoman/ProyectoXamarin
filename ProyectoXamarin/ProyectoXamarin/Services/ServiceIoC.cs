using Autofac;
using ProyectoXamarin.ViewModels;

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
            builder.RegisterType<EquipoViewModel>();
            builder.RegisterType<JugadorViewModel>();
            builder.RegisterType<LigaViewModel>();
            builder.RegisterType<PartidoViewModel>();
            this.container = builder.Build();
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
    }
}
