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
    public partial class PrioridadA : ContentPage
    {
        public ObservableCollection<Tareas> Items { get; set; }
        SQLiteConnection database;

        public PrioridadA()
        {

            InitializeComponent();

            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Practica1.db");
            database = new SQLiteConnection(db);
            database.CreateTable<Tareas>();

            Items = new ObservableCollection<Tareas>(database.Table<Tareas>().Where(Tareas => Tareas.Fecha_entrega ==Globales.FechaActual && Tareas.Responsable == Globales.Usuario && Tareas.Status !="No Completada"));
            BindingContext = this;

        }
    }
}