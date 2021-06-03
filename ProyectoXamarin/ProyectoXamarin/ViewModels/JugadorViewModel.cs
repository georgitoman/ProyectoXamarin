using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Services;

namespace ProyectoXamarin.ViewModels
{
    public class JugadorViewModel : ViewModelBase
    {
        public JugadorViewModel(ServiceEquipos service)
        {
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
    }
}
