using ProyectoXamarin.Views;
using Xamarin.Forms;

namespace ProyectoXamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LigasView), typeof(LigasView));
            Routing.RegisterRoute(nameof(EquiposView), typeof(EquiposView));
            Routing.RegisterRoute(nameof(JugadoresView), typeof(JugadoresView));
            Routing.RegisterRoute(nameof(PartidosView), typeof(PartidosView));
        }

    }
}
