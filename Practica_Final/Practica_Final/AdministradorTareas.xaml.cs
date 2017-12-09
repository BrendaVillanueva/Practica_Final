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
    public partial class AdministradorTareas : ContentPage
    {
        public ObservableCollection<Tareas> Items { get; set; }
        SQLiteConnection database;

        public AdministradorTareas()
        {
            InitializeComponent();
        

            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Practica1.db");
            database = new SQLiteConnection(db);
            database.CreateTable<Tareas>();


            if (Globales.Rol=="Usuario")
            {
                Items = new ObservableCollection<Tareas>(database.Table<Tareas>().Where(Tareas => Tareas.Responsable == Globales.Usuario));
                BindingContext = this;
                Inicio_Volver.IsVisible = false;
                Prioridad_A.IsEnabled = true;
                Prioridad_A.IsVisible = true;
                Prioridad_B.IsEnabled = true;
                Prioridad_B.IsVisible = true;
            }

            else
            {
                Items = new ObservableCollection<Tareas>(database.Table<Tareas>());
                BindingContext = this;
            }

        }


        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushAsync(new TareaSelect(e.SelectedItem as Tareas));
        }

        private void Inicio_Volver_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InicioData());
        }

        private void Prioridad_A_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrioridadA());
        }

        private void Prioridad_B_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrioridadB());

        }
    }
}