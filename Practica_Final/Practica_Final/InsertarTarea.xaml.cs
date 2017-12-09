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
    public partial class InsertarTarea : ContentPage
    {
        SQLiteConnection database;


        public InsertarTarea()
        {
            InitializeComponent();

            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Practica1.db");
            database = new SQLiteConnection(db);
            database.CreateTable<Tareas>();

            string[] prioridad = { "Urgente", "Normal" };
            Picker_Prioridad.ItemsSource = prioridad;

            var constareas = database.Query<Tareas>("select Nombre_tareas from Administrador_Tareas");
            string[] dependenci = new string[constareas.Count()];
            int e = 0;
            foreach (var depen in constareas)
            {
                dependenci[e] = depen.Nombre_tareas;
                e++;
            }
            Picker_Dependencia.ItemsSource = dependenci;

            string[] status = { "Creada", "En Ejecucion","Completada","No Completada" };
            Picker_Status.ItemsSource = status;

            var consultanom = database.Query<Usuarios13090416>("select Nombre from Usuarios");
            string[] usuarios = new string[consultanom.Count()];
            int i = 0;
            foreach (var usuario in consultanom)
            {
                usuarios[i] = usuario.Nombre;
                i++;
            }
            Picker_Responsable.ItemsSource = usuarios;

        }

        private void Insertar_Tarea_Clicked(object sender, EventArgs e)
        {
            var datos = new Tareas
            {
                Id_tareas=Entry_IdT.Text,
                Nombre_tareas=Entry_NombreT.Text,
                Descripcion=Entry_Descripcion.Text,
                Responsable=Convert.ToString(Picker_Responsable.SelectedItem),
                Prioridad=Convert.ToString(Picker_Prioridad.SelectedItem),
                Fecha_entrega=Picker_FechaE.Date,
                Dependencia=Convert.ToString(Picker_Dependencia.SelectedItem),
                Status=Convert.ToString(Picker_Status.SelectedItem)

            };
            database.Insert(datos);
            Navigation.PushAsync(new AdministradorTareas());


        }

    }
}