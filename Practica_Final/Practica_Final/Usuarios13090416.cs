using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace Practica_Final
{
    [Table("Usuarios")]

    public class Usuarios13090416
    {
        string id;
        string nombre;
        string password;
        string rol;


        [PrimaryKey,MaxLength(10),Unique]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }


        [MaxLength(35),Unique]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [MaxLength(10)]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [MaxLength(30)]
        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }

    }
}
