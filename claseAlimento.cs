using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cafetería_Luna
{
    class claseAlimento
    {
        public int id_alimento { get; set; }
        public string nombre_alimento { get; set; }
        public string tipo_alimento { get; set; }
        public double precio_alimento { get; set; }
        public string descripcion_alimento { get; set; }
        public int estado_alimento { get; set; }

        public claseAlimento()
        {

        }
        public claseAlimento(int id, string nombre, string tipo, double precio, string descripcion, int estado)
        {
            this.id_alimento = id;
            this.nombre_alimento = nombre;
            this.tipo_alimento = tipo;
            this.precio_alimento = precio;
            this.descripcion_alimento = descripcion;
            this.estado_alimento = estado;
        }
    }
}
