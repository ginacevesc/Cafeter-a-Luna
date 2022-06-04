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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        MySqlConnection conexion = new MySqlConnection("server=127.0.0.1;database=cafeteria;Uid=root;pwd=g1n4;");

        public void log(string codigo, string password)
        {
            try
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT nombre_usuario, tipo_usuario FROM usuario WHERE codigo_usuario = @code AND password_usuario = @pass AND estado_usuario !=0", conexion);
                cmd.Parameters.AddWithValue("code", codigo);
                cmd.Parameters.AddWithValue("pass", password);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][1].ToString() == "administrador")
                    {
                        this.Hide();
                        btnEliminarUsuario admi = new btnEliminarUsuario(dt.Rows[0][0].ToString(), txtCodigo.Text);
                        txtPassword.Clear();
                        txtCodigo.Clear();
                        admi.ShowDialog();
                        this.Show();
                    }
                    else if (dt.Rows[0][1].ToString() == "usuario")
                    {
                        this.Hide();
                        MenuUsuario user = new MenuUsuario(dt.Rows[0][0].ToString(), txtCodigo.Text);
                        txtPassword.Clear();
                        txtCodigo.Clear();
                        user.ShowDialog();
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario/Contraseña incorrectos.");
                    txtPassword.Clear();
                    txtCodigo.Clear();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuUsuario user = new MenuUsuario("Gina", txtCodigo.Text);
            txtPassword.Clear();
            txtCodigo.Clear();
            user.ShowDialog();
            this.Show();
            //log(this.txtCodigo.Text, this.txtPassword.Text);
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
