using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JugadoresView : ContentPage
    {
        public JugadoresView()
        {
            InitializeComponent();
            this.listviewjugadores.ItemSelected += ListViewJugadores_ItemSelected;
        }

        private void ListViewJugadores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            if (sender is ListView lv) lv.SelectedItem = null;
        }
    }
}