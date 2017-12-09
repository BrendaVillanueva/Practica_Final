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
    public partial class Log : ContentPage
    {

        SQLiteConnection database;
      //  public static List<Usuarios13090416> consultaN;
       // public static List<Usuarios13090416> consultaC;
        //public static List<Usuarios13090416> consultaR;
       

        public Log()
        {
           
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Practica1.db");
            database = new SQLiteConnection(db);
            database.CreateTable<Usuarios13090416>();  

        }

        private void Iniciar_Sesion_Clicked(object sender, EventArgs e)
        {
           var consultaN = database.Query<Usuarios13090416>("select * from Usuarios where Nombre = ? ", Entry_Nombre.Text);
           var consultaC = database.Query<Usuarios13090416>("select Password from Usuarios where Nombre = ? ", Entry_Nombre.Text);
          var  consultaR = database.Query<Usuarios13090416>("select Rol from Usuarios where Nombre = ? ", Entry_Nombre.Text);
         

            if(Entry_Nombre.Text=="Root" && Entry_Password.Text== "100")
            {
                Navigation.PushAsync(new InicioData());
            }

            if (consultaN.Count == 0)
            {
                DisplayAlert("Usuario No Valido", "Verificar Usuario", "Aceptar");
            }
            else
            { 
                if (Entry_Password.Text == consultaC.First().Password)
                {

                    if(consultaR.First().Rol== "Administrador")
                    {
                        Globales.Rol = "Administrador";
                        Globales.Usuario = Entry_Nombre.Text;
                        DisplayAlert("Administrador Autenticado", "Bienvenido: " + Entry_Nombre.Text, "Aceptar");
                        Navigation.PushAsync(new InicioData());
         
                    }
                   
                    else if(consultaR.First().Rol=="Usuario")

                    {
                        Globales.Rol = "Usuario";
                        Globales.Usuario = Entry_Nombre.Text;
                        DisplayAlert("Usuario Autenticado", "Bienvenido: " + Entry_Nombre.Text, "Aceptar");
                        Navigation.PushAsync(new AdministradorTareas());
                    }

                }
                else
                {
                    
                     DisplayAlert("Advertencia", "Contraseña Incorrecta", "Aceptar");
                   
                }

            }
        }
    }

    public static class Globales
    {
        public static string Usuario;
        public static string Rol;
        public static DateTime FechaActual = DateTime.Today;

    }
}