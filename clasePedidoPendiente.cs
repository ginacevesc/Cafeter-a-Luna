using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cafetería_Luna
{
    class clasePedidoPendiente
    {
        public int id_pedidop { get; set; }
        public int num_orden { get; set; }
        public int id_alimentop { get; set; }
        public int cantidadp { get; set; }
        public int estadop { get; set; }

        public clasePedidoPendiente()
        {

        }

        public clasePedidoPendiente(int id_pedido, int num, int id_alimento, int cantidad, int estado)
        {
            this.id_pedidop = id_pedido;
            this.num_orden = num;
            this.id_alimentop = id_alimento;
            this.cantidadp = cantidad;
            this.estadop = estado;
        }
    }
}
