using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;


namespace Practica_Final
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataUsuario : ContentPage
    {

        public ObservableCollection<Usuarios13090416> Items { get; set; }
        SQLiteConnection database;

        public DataUsuario()
        {

            InitializeComponent();

            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Practica1.db");
            database = new SQLiteConnection(db);
            database.CreateTable<Usuarios13090416>();

            Items = new ObservableCollection<Usuarios13090416>(database.Table<Usuarios13090416>());
            BindingContext = this;

        }

            async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
            {
                if (e.SelectedItem == null)
                    return;
                await Navigation.PushAsync(new SelectPage(e.SelectedItem as Usuarios13090416));
            }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
                Navigation.PushAsync(new Insertar_Usuario());
            
        }

        private void Button_Inicio_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InicioData());
        }
    }
}