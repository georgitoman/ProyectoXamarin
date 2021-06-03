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
    public partial class PartidosView : ContentPage
    {
        public PartidosView()
        {
            InitializeComponent();
            this.listviewpartidos.ItemSelected += ListViewPartidos_ItemSelected;
        }

        private void ListViewPartidos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            if (sender is ListView lv) lv.SelectedItem = null;
        }
    }
}