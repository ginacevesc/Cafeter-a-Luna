using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cafetería_Luna
{
    class claseCuenta
    {
        //public int id_cuenta { get; set; }
        public int num_orden { get; set; }
        public double iva { get; set; }
        public double subtotal { get; set; }
        public double total { get; set; }
        public DateTime fecha { get; set; }
        public string atendio { get; set; }

        public claseCuenta()
        {

        }

        public claseCuenta(int orden, double porcentaje, double subt, double tot, DateTime fech, string usuario)
        {
            //this.id_cuenta = cuenta;
            this.num_orden = orden;
            this.iva = porcentaje;
            this.subtotal = subt;
            this.total = tot;
            this.fecha = fech;
            this.atendio = usuario;
        }
    }
}
