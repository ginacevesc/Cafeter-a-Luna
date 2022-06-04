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
    public partial class ModificarAlimento : Form
    {
        string nombre, tipo, descripcion;
        int estado, id;
        double precio;
        MySqlConnection conexion = new MySqlConnection("server=127.0.0.1;database=cafeteria;Uid=root;pwd=g1n4;");

        public ModificarAlimento()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void IconCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RadioCaliente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ComboLista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ModificarAlimento_Load(object sender, EventArgs e)
        {
            MySqlCommand comandoAlimento = new MySqlCommand(String.Format("select * from alimento"), claseConexion.obtenerConexion());
            MySqlDataReader readerAlimento = comandoAlimento.ExecuteReader();

            while (readerAlimento.Read())
            {
                comboTipo.Refresh();
                //comboTipo.Items.Add(readerAlimento.GetValue(0).ToString());
            }
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboTipo.Text != null)
            {
                string tipo_alimento = comboTipo.Text.ToString();
                cargarAlimentos(tipo_alimento);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0 || txtPrecio.Text.Length == 0 || (radioBCaliente.Checked == false &&
                radioBFria.Checked == false && radioComida.Checked == false) || (radioActivo.Checked == false && radioInactivo.Checked == false))
            {
                MessageBox.Show("No se han llenado uno o más campos obligatorios.");
            }
            else
            {
                MySqlCommand comando = new MySqlCommand(String.Format("SELECT id_alimento FROM alimento WHERE nombre_alimento = '{0}'" +
                    "AND tipo_alimento = '{1}'", comboLista.Text, comboTipo.Text), claseConexion.obtenerConexion());
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                claseAlimento alimento = new claseAlimento();
                //MessageBox.Show(id.ToString());
                alimento.id_alimento = id;

                alimento.nombre_alimento = txtNombre.Text;

                if (radioBCaliente.Checked == true)
                {
                    alimento.tipo_alimento = "Bebida Caliente";
                }
                else if (radioBFria.Checked == true)
                {
                    alimento.tipo_alimento = "Bebida Fria";
                }
                else if (radioComida.Checked == true)
                {
                    alimento.tipo_alimento = "Comida";
                }

                alimento.precio_alimento = Convert.ToDouble(txtPrecio.Text);

                alimento.descripcion_alimento = txtDescripcion.Text;

                if(radioActivo.Checked == true)
                {
                    alimento.estado_alimento = 1;
                }
                else if(radioInactivo.Checked == true)
                {
                    alimento.estado_alimento = 0;
                }

                int retorno = Funciones.modificarAlimento(alimento);
                if(retorno > 0)
                {
                    MessageBox.Show("Alimento actualizado.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al actualizar alimento.");
                }
            }
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
                txtNombre.Text = nombre;

                if (tipo == "Bebida Caliente")
                {
                    radioBCaliente.Checked = true;
                }
                else if (tipo == "Bebida Fria")
                {
                    radioBFria.Checked = true;
                }
                else if (tipo == "Comida")
                {
                    radioComida.Checked = true;
                }

                txtPrecio.Text = precio.ToString();

                txtDescripcion.Text = descripcion;

                if (estado == 1)
                {
                    radioActivo.Checked = true;
                }
                else
                {
                    radioInactivo.Checked = true;
                }
            }
        }
    } 
}

