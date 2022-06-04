using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cafetería_Luna
{
    class claseHistorialPedidos
    {
        public int id_historialp { get; set; }
        public int id_pedidop { get; set; }
        public int cantidad_h { get; set; }
        public double total_historial { get; set; }
        public string fecha_h { get; set; }

        claseHistorialPedidos()
        {

        }

        claseHistorialPedidos(int id_historial, int id_pedido, int cantidad, double total, string fecha)
        {
            this.id_historialp = id_historial;
            this.id_pedidop = id_pedido;
            this.cantidad_h = cantidad;
            this.total_historial = total;
            this.fecha_h = fecha;
        }
    }
}
