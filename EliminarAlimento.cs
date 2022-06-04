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
    public partial class EliminarAlimento : Form
    {
        string nombre, tipo, descripcion;
        int estado, id;
        double precio;
        MySqlConnection conexion = new MySqlConnection("server=127.0.0.1;database=cafeteria;Uid=root;pwd=g1n4;");
        public EliminarAlimento()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void IconCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void cargarDatos()
        {
            conexion.Open();
            MySqlCommand comando = new MySqlCommand("select distinct tipo_alimento from alimento", conexion);
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.Close();

            DataRow fila = dt.NewRow();
            comboTipo.ValueMember = "id_alimento";
            comboTipo.DisplayMember = "tipo_alimento";
            comboTipo.DataSource = dt;
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipo.Text != null)
            {
                string tipo_alimento = comboTipo.Text.ToString();
                cargarAlimentos(tipo_alimento);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT id_alimento FROM alimento WHERE nombre_alimento = '{0}'" +
                    "AND tipo_alimento = '{1}'", comboLista.Text, comboTipo.Text), claseConexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }

            //MessageBox.Show(id.ToString());

            int retorno = Funciones.eliminarAlimento(id);
            if(retorno > 0)
            {
                MessageBox.Show("Alimento eliminado.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al eliminar alimento.");
            }
        }

        public void cargarAlimentos(string tipo_alimento)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT nombre_alimento FROM alimento where " +
                "tipo_alimento = '{0}'", tipo_alimento), claseConexion.obtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboLista.DisplayMember = "nombre_alimento";
            comboLista.DataSource = dt;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT nombre_alimento, tipo_alimento, " +
                "precio_alimento, descripcion_alimento, estado_alimento FROM alimento where tipo_alimento = '{0}' and " +
                "nombre_alimento = '{1}'", comboTipo.Text, comboLista.Text), claseConexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                nombre = reader.GetString(0);
                tipo = reader.GetString(1);
                precio = reader.GetDouble(2);
                descripcion = reader.GetString(3);
                estado = reader.GetInt32(4);
            }
            if (comboLista.Text.Length == 0)
            {
                MessageBox.Show("Seleccione un alimento.");
            }
            else if (nombre != comboLista.Text)
            {
                MessageBox.Show("No se encontró ese alimento.");
            }
            else
            {
                txtDatos.Text = ("\r\rNombre: " + nombre + "\r" +
                "\n" + "Tipo: " + tipo + "\n" + "Precio: " + precio + "\n" + "Descripción: " + descripcion +
                "\n" + "Estado: " + estado);
                btnEliminar.Enabled = true;
            }
         }

        private void EliminarAlimento_Load(object sender, EventArgs e)
        {
            MySqlCommand comandoAlimento = new MySqlCommand(String.Format("select * from alimento"), claseConexion.obtenerConexion());
            MySqlDataReader readerAlimento = comandoAlimento.ExecuteReader();

            while (readerAlimento.Read())
            {
                comboTipo.Refresh();
                //comboTipo.Items.Add(readerAlimento.GetValue(0).ToString());
            }
        }
    }
}
