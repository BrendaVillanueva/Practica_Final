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
    public partial class TareaSelect : ContentPage
    {
        SQLiteConnection database;

        public TareaSelect(object selectedItem)
        {
            var dato = selectedItem as Tareas;
            BindingContext = dato;

            InitializeComponent();

            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Practica1.db");
            database = new SQLiteConnection(db);
            database.CreateTable<Tareas>();


            string[] prioridad = {"Urgente", "Normal" };
            Picker_Prioridad.ItemsSource = prioridad;
            Picker_Prioridad.SelectedItem = dato.Prioridad;


            var constareas = database.Query<Tareas>("select Nombre_tareas from Administrador_Tareas");
            string[] dependenci = new string[constareas.Count()];
            int e = 0;
            foreach (var depen in constareas)
            {
                dependenci[e] = depen.Nombre_tareas;
                e++;
            }
            Picker_Dependencia.ItemsSource = dependenci;
            Picker_Dependencia.SelectedItem = dato.Dependencia;


            string[] status = {"Creada", "En Ejecucion", "Completada", "No Completada"};
            string[] status01 = { "En Ejecucion", "Completada"};
            Picker_Status.ItemsSource = status;
            Picker_Status.SelectedItem = dato.Status;


            var consultanomS = database.Query<Usuarios13090416>("select Nombre from Usuarios");
            string[] usuarios = new string[consultanomS.Count()];
            int i = 0;
            foreach (var usuario in consultanomS)
            {
                usuarios[i] = usuario.Nombre;
                i++;
            }
            Picker_Responsable.ItemsSource = usuarios;
            Picker_Responsable.SelectedItem = dato.Responsable;


            if (Globales.Rol == "Usuario")
            {
                Entry_NombreT.IsEnabled = false;
                Entry_Descripcion.IsEnabled = false;
                Picker_Responsable.IsEnabled = false;
                Picker_Prioridad.IsEnabled = false;
                Picker_FechaE.IsEnabled = false;
                Picker_Dependencia.IsEnabled = false;
                Button_Eliminar.IsVisible = false;

                Picker_Status.ItemsSource = status01;
                Picker_Status.SelectedItem = dato.Status;
            }


            var consdep = database.Query<Tareas>("select Status from Administrador_Tareas where Nombre_tareas=?", Convert.ToString(Picker_Dependencia.SelectedItem));
             if (consdep.Count == 0)
            {
                Picker_Status.IsEnabled = true;
            }
            else
            {
                if (consdep.First().Status != "Completada")
                {
                    Picker_Status.IsEnabled = false;
                }
            }


        }

        private void Button_Actualizar_Clicked(object sender, EventArgs e)
        {
            var datos = new Tareas
            {
                Id_tareas = Entry_IdTA.Text,
                Nombre_tareas = Entry_NombreT.Text,
                Descripcion = Entry_Descripcion.Text,
                Responsable= Convert.ToString(Picker_Responsable.SelectedItem),
                Prioridad = Convert.ToString(Picker_Prioridad.SelectedItem),
                Fecha_entrega = Picker_FechaE.Date,
                Dependencia = Convert.ToString(Picker_Dependencia.SelectedItem),
                Status = Convert.ToString(Picker_Status.SelectedItem),

            };
            database.Update(datos);
            Navigation.PushAsync(new AdministradorTareas());
        }


        private void Button_Eliminar_Clicked(object sender, EventArgs e)
        {
            var datos = new Tareas
            {
                Id_tareas = Entry_IdTA.Text,
               
            };
            database.Delete(datos);
            Navigation.PushAsync(new AdministradorTareas());

        }
    }
}