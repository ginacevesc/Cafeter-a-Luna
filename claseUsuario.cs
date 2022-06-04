using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cafetería_Luna
{
    class claseUsuario
    {
        public int id_usuario { get; set; }
        public string tipo_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string apellidos_usuario { get; set; }
        public string telefono_usuario { get; set; }
        public string codigo_usuario { get; set; }
        public string password_usuario { get; set; }
        public int estado_usuario { get; set; }

        claseUsuario()
        {

        }

        claseUsuario(int id, string tipo, string nombre, string apellidos, string telefono, string codigo, string password, int estado)
        {
            this.id_usuario = id;
            this.tipo_usuario = tipo;
            this.nombre_usuario = nombre;
            this.apellidos_usuario = apellidos;
            this.telefono_usuario = telefono;
            this.codigo_usuario = codigo;
            this.password_usuario = password;
            this.estado_usuario = estado;
        }
    }
}
