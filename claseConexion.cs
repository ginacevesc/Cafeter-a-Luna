using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cafetería_Luna
{
    public class claseConexion
    {
        public static MySqlConnection obtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection("server=127.0.0.1;database=cafeteria;Uid=root;pwd=g1n4;");
            conexion.Open();
            return conexion;
        }
    }
}
