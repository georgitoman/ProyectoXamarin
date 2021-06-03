using ProyectoXamarin.Models;
using ProyectoXamarin.Services;
using ProyectoXamarin.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JugadoresView : ContentPage
    {
        private ServiceEquipos Service;

        public JugadoresView()
        {
            InitializeComponent();
        }

        public Command DetallesJugador
        {
            get
            {
                return new Command(async (jug) =>
                {
                    Jugador jugador = jug as Jugador;
                    JugadorViewModel viewmodel = App.ServiceLocator.JugadorViewModel;
                    viewmodel.Jugador = jugador;
                    DetailsJugadorView view = new DetailsJugadorView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }

        public Command DetallesEquipo
        {
            get
            {
                return new Command(async (jug) =>
                {
                    this.Service = new ServiceEquipos();
                    Jugador jugador = jug as Jugador;
                    EquipoViewModel viewmodel = App.ServiceLocator.EquipoViewModel;
                    Equipo equipo = await this.Service.BuscarEquipoAsync(jugador.IdEquipo);
                    viewmodel.Equipo = equipo;
                    DetailsEquipoView view = new DetailsEquipoView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}