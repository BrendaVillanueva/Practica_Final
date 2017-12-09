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
    public partial class PrioridadAdmin : ContentPage
    {

        public ObservableCollection<Tareas> Items { get; set; }
        SQLiteConnection database;

        public PrioridadAdmin()
        {
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Practica1.db");
            database = new SQLiteConnection(db);
            database.CreateTable<Tareas>();

            Items = new ObservableCollection<Tareas>(database.Table<Tareas>().Where(Tareas => Tareas.Status== "No Completada"));
            BindingContext = this;

        }

        private void Inicio_Volver_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdministradorTareas());
        }
    }
}