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
    public partial class SelectPage : ContentPage
    {
        SQLiteConnection database;

        public SelectPage(object selectedItem)
        {
           
            var dato = selectedItem as Usuarios13090416;
            BindingContext = dato;

            InitializeComponent();

            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Practica1.db");
            database = new SQLiteConnection(db);

            string[] role = {"Administrador","Usuario" };
            Picker_Rol.ItemsSource = role;
            Picker_Rol.SelectedItem = dato.Rol;

        }

        private void Button_Actualizar_Clicked(object sender, EventArgs e)
        {
            var datos = new Usuarios13090416
            {
                Id = Entry_Id.Text,
                Nombre = Entry_Nombre.Text,
                Password = Entry_Password.Text,
                Rol = Convert.ToString(Picker_Rol.SelectedItem),


            };
            database.Update(datos);
            Navigation.PushAsync(new DataUsuario());

        }

        private void Button_Eliminar_Clicked(object sender, EventArgs e)
        {
            var datos = new Usuarios13090416
            {
                Id = Entry_Id.Text,
               
            };
            database.Delete(datos);
            Navigation.PushAsync(new DataUsuario());
        }
    }
}