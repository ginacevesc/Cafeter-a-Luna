using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Cafetería_Luna
{
    public partial class CancelarPedido : Form
    {
        string nombre;
        int cantidad, norden, id;
        public CancelarPedido()
        {
            InitializeComponent();
        }

        private void IconCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelarPedido_Load(object sender, EventArgs e)
        {
            MySqlCommand comandoOrden = new MySqlCommand(String.Format("select num_orden from pedido_pendiente where estado_pedidop = '{0}'", 1), claseConexion.obtenerConexion());
            MySqlDataReader readerOrden = comandoOrden.ExecuteReader();

            while (readerOrden.Read())
            {
                comboOrden.Refresh();
                comboOrden.Items.Add(readerOrden.GetValue(0).ToString());
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(id.ToString());
            id = Convert.ToInt32(comboOrden.Text);
            int retorno = Funciones.cancelarPedido(id);
            if (retorno > 0)
            {
                MessageBox.Show("Pedido eliminado.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al eliminar pedido.");
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT pedido_pendiente.num_orden, alimento.nombre_alimento, pedido_pendiente.cantidad_pedidop " +
                "FROM pedido_pendiente INNER JOIN alimento on pedido_pendiente.id_alimentopedidop = alimento.id_alimento WHERE pedido_pendiente.estado_pedidop = '{0}'", 1), claseConexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                norden = reader.GetInt32(0);
                nombre = reader.GetString(1);
                cantidad = reader.GetInt32(2);
            }
            if (comboOrden.Text.Length == 0)
            {
                MessageBox.Show("Seleccione un Número de Orden.");
            }
            else if (norden != Convert.ToInt32(comboOrden.Text))
            {
                MessageBox.Show("No se encontró ese Pedido.");
            }
            else
            {
                MySqlCommand comandoG = new MySqlCommand(string.Format("SELECT pedido_pendiente.num_orden AS NUM_ORDEN, " +
                "alimento.nombre_alimento AS ALIMENTO, pedido_pendiente.cantidad_pedidop AS CANTIDAD FROM pedido_pendiente " +
                "INNER JOIN alimento on pedido_pendiente.id_alimentopedidop = alimento.id_alimento WHERE pedido_pendiente.estado_pedidop = '{0}'", 1), claseConexion.obtenerConexion());
                MySqlDataAdapter da = new MySqlDataAdapter(comandoG);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPendientes.DataSource = dt;
            }
        }
    }
}
