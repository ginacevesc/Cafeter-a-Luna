using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cafetería_Luna
{
    class Funciones
    {
        public static int codigoUsuario()
        {
            MySqlCommand comando = new MySqlCommand(string.Format("select * from usuario"), claseConexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            if(id == 0)
            {
                id += 1;
                return id;
            }
            else
            {
                id += 1;
                return id;
            }
        }

        public static int codigoAlimento()
        {
            MySqlCommand comando = new MySqlCommand(string.Format("select * from alimento"), claseConexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            if (id == 0)
            {
                id += 1;
                return id;
            }
            else
            {
                id += 1;
                return id;
            }
        }

        public static int codigoPedido()
        {
            string prueba = "";
            MySqlCommand comando = new MySqlCommand(string.Format("select MAX id_pedidop from pedido_pendiente"), claseConexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            if (Convert.ToString(id).Length == prueba.Length )
            {
                id = 1;
                return id;
            }
            else
            {
                id += 1;
                return id;
            }
        }

        public static int codigoNumOrden()
        {
            MySqlCommand comando = new MySqlCommand(string.Format("select MAX num_orden from pedido_pendiente"), claseConexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            if (id == 0)
            {
                id += 1;
                return id;
            }
            else
            {
                id += 1;
                return id;
            }
        }

        public static int RegistarAlimento(claseAlimento alimento)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO alimento(id_alimento, nombre_alimento, tipo_alimento, " +
                "precio_alimento, descripcion_alimento, estado_alimento) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", alimento.id_alimento,
                alimento.nombre_alimento, alimento.tipo_alimento, alimento.precio_alimento, alimento.descripcion_alimento, +
                alimento.estado_alimento), claseConexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int modificarAlimento(claseAlimento alimento)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE alimento SET nombre_alimento = '{0}', tipo_alimento = '{1}', precio_alimento = '{2}', descripcion_alimento = '{3}', estado_alimento = '{4}' WHERE id_alimento = '{5}'", alimento.nombre_alimento,
                alimento.tipo_alimento, alimento.precio_alimento, alimento.descripcion_alimento, alimento.estado_alimento, alimento.id_alimento), claseConexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int eliminarAlimento(int id)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE alimento SET estado_alimento = '{0}' WHERE id_alimento = '{1}'", 0, id), claseConexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public void mostrarPendientes(DataGridView grid)
        {
            MySqlCommand comando = new MySqlCommand(string.Format("SELECT pedido_pendiente.num_orden AS NUM_ORDEN, " +
                "alimento.nombre_alimento AS ALIMENTO, pedido_pendiente.cantidad_pedidop AS CANTIDAD FROM pedido_pendiente " +
                "INNER JOIN alimento on pedido_pendiente.id_alimentopedidop = alimento.id_alimento WHERE pedido_pendiente.estado_pedidop = '{0}'", 1), claseConexion.obtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(comando);

            DataTable dt = new DataTable();
            da.Fill(dt);

            grid.DataSource = dt;
        }

        public static int terminarPedidoPendiente(int num_o)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE pedido_pendiente SET estado_pedidop = '{0}' WHERE num_orden = '{1}'", -1, num_o), claseConexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int cancelarPedido(int id)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Delete from pedido_pendiente WHERE num_orden = '{0}'", id), claseConexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int agregarCuenta(claseCuenta cuenta)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO cuenta (num_orden, iva, subtotal, " +
                "total, fecha, atendio) VALUES ('{0}', '{1}', '{2}', '{3}', {4}', '{5}')", cuenta.num_orden, cuenta.iva,
                cuenta.subtotal, cuenta.total, cuenta.fecha, cuenta.atendio), claseConexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
    }
}
