
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquiposView : ContentPage
    {
        public EquiposView()
        {
            InitializeComponent();
            this.listviewequipos.ItemSelected += ListViewEquipos_ItemSelected;
        }

        private void ListViewEquipos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            if (sender is ListView lv) lv.SelectedItem = null;
        }
    }
}