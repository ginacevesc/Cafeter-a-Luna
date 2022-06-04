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
    public partial class Cuenta : Form
    {
        int num_o;
        public Cuenta()
        {
            InitializeComponent();
        }

        private void Cuenta_Load(object sender, EventArgs e)
        {
            MySqlCommand comandoOrden = new MySqlCommand(String.Format("select num_orden from pedido_pendiente where estado_pedidop = '{0}'", -1), claseConexion.obtenerConexion());
            MySqlDataReader readerOrden = comandoOrden.ExecuteReader();

            while (readerOrden.Read())
            {
                comboOrden.Refresh();
                comboOrden.Items.Add(readerOrden.GetValue(0).ToString());
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT num_orden FROM pedido_pendiente WHERE estado_pedidop = -1"), claseConexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                num_o = reader.GetInt32(0);
            }
            if (comboOrden.Text.Length == 0)
            {
                MessageBox.Show("No se han llenado un campo obligatorio.");
            }

            else
            {
                MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=cafeteria;Uid=root;pwd=g1n4;");
                //int estado = 1;
                con.Open();
                MySqlCommand comm = new MySqlCommand(string.Format("SELECT pedido_pendiente.cantidad_pedidop AS CANTIDAD, alimento.nombre_alimento AS ALIMENTO, alimento.precio_alimento AS PRECIO, alimento.precio_alimento*pedido_pendiente.cantidad_pedidop AS IMPORTE FROM pedido_pendiente INNER JOIN alimento ON pedido_pendiente.id_alimentopedidop = alimento.id_alimento WHERE pedido_pendiente.num_orden = '{0}'", comboOrden.Text), con);
                //MySqlCommand comm = new MySqlCommand(string.Format("Select pedido.cantidad_platillo, alimento.nombre_alimento, alimento.precio_alimento FROM pedido INNER JOIN alimento ON pedido.id_alimento = alimento.id_alimento WHERE pedido.num_orden = '{0}'", txtNOrden.Text), con);
                DataTable dt = new DataTable();
                MySqlDataAdapter SDA = new MySqlDataAdapter(comm);
                //DataTable dt = new DataTable();
                SDA.Fill(dt);
                dgvCuenta.DataSource = dt;
            }
            int contador = 0;
            double suma = 0;
            foreach (DataGridViewRow R in dgvCuenta.Rows)
            {
                if (contador < dgvCuenta.Rows.Count - 1 || contador == dgvCuenta.Rows.Count - 1)
                {
                    dgvCuenta.Rows[contador].Selected = true;
                    suma = int.Parse(dgvCuenta.SelectedRows[0].Cells["IMPORTE"].Value.ToString()) + suma;
                    contador = contador + 1;
                }
            }
            txtSubtotal.Text = suma.ToString();
            double tot = suma * 0.16;
            txtTotal.Text = tot.ToString();

            claseCuenta cuenta = new claseCuenta();
            cuenta.num_orden = Convert.ToInt32(comboOrden.Text);
            cuenta.iva = 0.16;
            cuenta.subtotal = Convert.ToInt32(txtSubtotal.Text);
            cuenta.total = Convert.ToInt32(txtTotal.Text);
            cuenta.atendio = txtAtendio.Text;
            cuenta.fecha = DateTime.Now;

            int retorno = Funciones.agregarCuenta(cuenta);
            if(retorno > 0)
            {
                MessageBox.Show("Cuenta Guardada.");
            }
            else
            {
                MessageBox.Show("No se pudo guardar la cuenta.");
            }
        }
    }
}
