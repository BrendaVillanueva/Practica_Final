using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Practica_Final
{

    [Table ("Administrador_Tareas")]
   public class Tareas
    {
        string id_tareas;
        string nombre_tareas;
        string descripcion;
        string responsable;
        string prioridad;
        DateTime fecha_entrega;
        string dependencia;
        string status;


        [PrimaryKey, MaxLength(10), Unique]
        public string Id_tareas
        {
            get { return id_tareas; }
            set { id_tareas= value; }
        }

        [MaxLength(30), Unique]
        public string Nombre_tareas
        {
            get { return nombre_tareas; }
            set { nombre_tareas = value; }
        }

        [MaxLength(80)]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        [MaxLength(80)]
        public string Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }

        [MaxLength(80)]
        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

       
        public DateTime Fecha_entrega
        {
            get { return fecha_entrega; }
            set { fecha_entrega = value; }
        }

        [MaxLength(80)]
        public string Dependencia
        {
            get { return dependencia; }
            set { dependencia = value; }
        }

        [MaxLength(80)]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
