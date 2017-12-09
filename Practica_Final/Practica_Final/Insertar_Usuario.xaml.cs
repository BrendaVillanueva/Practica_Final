using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace Practica_Final
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insertar_Usuario : ContentPage
    {
        SQLiteConnection database;

        public Insertar_Usuario()
        {
            
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Practica1.db");
            database = new SQLiteConnection(db);
            string[] role = { "Administrador","Usuario" };
            Picker_Rol.ItemsSource = role;
         
        }

        private void Button_Insertar_Clicked(object sender, EventArgs e)
        {
            var datos = new Usuarios13090416
            {
                Id =Entry_Id.Text,
                Nombre = Entry_Nombre.Text,
                Password = Entry_Password.Text,
                Rol= Convert.ToString(Picker_Rol.SelectedItem),


            };
            database.Insert(datos);
            Navigation.PushAsync(new DataUsuario());

        }

     
    }
}