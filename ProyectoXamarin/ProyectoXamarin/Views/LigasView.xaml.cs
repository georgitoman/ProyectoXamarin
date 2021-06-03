using ProyectoXamarin.Models;
using ProyectoXamarin.ViewModels;

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

        public Command DetallesLiga
        {
            get
            {
                return new Command(async (lig) =>
                {
                    Liga liga = lig as Liga;
                    LigaViewModel viewmodel = App.ServiceLocator.LigaViewModel;
                    viewmodel.Liga = liga;
                    DetailsLigaView view = new DetailsLigaView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}