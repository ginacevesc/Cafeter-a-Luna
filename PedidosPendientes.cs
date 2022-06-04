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
    public partial class PedidosPendientes : Form
    {
        Funciones fn = new Funciones();
        int num_o;
        public PedidosPendientes()
        {
            InitializeComponent();
        }

        private void TxtDatos_TextChanged(object sender, EventArgs e)
        {

        }

        private void PedidosPendientes_Load(object sender, EventArgs e)
        {
            fn.mostrarPendientes(dgvPendientes);
            int estado = 1;

            MySqlCommand comando = new MySqlCommand(String.Format("select distinct num_orden from pedido_pendiente where estado_pedidop = '{0}'", estado), claseConexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                comboOrden.Refresh();
                comboOrden.Items.Add(reader.GetValue(0).ToString());
            }
        }

        private void ComboOrden_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnListo_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("select distinct num_orden from pedido_pendiente where estado_pedidop = '{0}'", 1), claseConexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                num_o = reader.GetInt32(0);
            }
            if (comboOrden.Text.Length == 0)
            {
                MessageBox.Show("Ingrese un número de orden válido.");
            }
            else if (num_o != Convert.ToInt32(comboOrden.Text))
            {
                MessageBox.Show("No se encontró ese número de orden.");
            }
            else
            {

                int retornoPP = Funciones.terminarPedidoPendiente(Convert.ToInt32(comboOrden.Text));
                if (retornoPP > 0)
                {
                    MessageBox.Show("Pedido Terminado.");
                    this.Close();
                }

                else
                {
                    MessageBox.Show("No se pudo completar el pedido.");
                }                
            }
        }
    }
}
