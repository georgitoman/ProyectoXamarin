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
    public partial class LigasView : ContentPage
    {
        public LigasView()
        {
            InitializeComponent();
            this.listviewligas.ItemSelected += ListViewLigas_ItemSelected;
        }

        private void ListViewLigas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            if (sender is ListView lv) lv.SelectedItem = null;
        }
    }
}