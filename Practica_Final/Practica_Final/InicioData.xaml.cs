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
    public partial class InicioData : ContentPage
    {
        public InicioData()
        {
            InitializeComponent();
        }

        private void Cons_Usuarios_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DataUsuario());
        }

        private void Cons_Tareas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdministradorTareas());
        }

        private void Asig_Tareas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertarTarea());
        }

        private void Tareas_P_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrioridadAdmin());
            
        }
    }
}