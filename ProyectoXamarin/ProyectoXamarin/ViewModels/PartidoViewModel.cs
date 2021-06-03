using ProyectoXamarin.Base;
using ProyectoXamarin.Models;

namespace ProyectoXamarin.ViewModels
{
    public class PartidoViewModel : ViewModelBase
    {

        public PartidoViewModel()
        {
            if (this.Partido == null)
            {
                this.Partido = new Partidos();
            }
        }

        private Partidos _Partido;
        public Partidos Partido
        {
            get { return this._Partido; }
            set
            {
                this._Partido = value;
                OnPropertyChanged("Partido");
            }
        }
    }
}
