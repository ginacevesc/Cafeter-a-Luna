using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Cafetería_Luna
{
    public partial class MenuUsuario : Form
    {
        string codigo_usuario;
        public MenuUsuario(string nombre, string texto)
        {
            InitializeComponent();
            codigo_usuario = Text;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public MenuUsuario()
        {

        }

        private void MenuUsuario_Load(object sender, EventArgs e)
        {

        }

        private void BtnSlide_Click(object sender, EventArgs e)
        {
            if(MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
            {
                MenuVertical.Width = 250;
            }
        }

        private void IconCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IconMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconRestaurar.Visible = true;
            iconMaximizar.Visible = false;
        }

        private void IconRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconRestaurar.Visible = false;
            iconMaximizar.Visible = true;
        }

        private void IconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormPanel(object Formhijo)
        {
            if(this.btnListaHistorialPedidos.Controls.Count > 0)
            {
                this.btnListaHistorialPedidos.Controls.RemoveAt(0);
            }
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.btnListaHistorialPedidos.Controls.Add(fh);
            this.btnListaHistorialPedidos.Tag = fh;
            fh.Show();
        }

        private void BtnNuevoPedido_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new NuevoPedido());
        }

        private void BtnModificarPedido_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new ModificarPedido());
        }

        private void BtnPedidosPendientes_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new PedidosPendientes());
        }

        private void PanelControlador_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnListaAlimentos_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new ListaAlimentos());
        }

        private void BtnHistorialP_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new ListaHistorialPedidos());
        }

        private void BtnCuenta_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Cuenta());
        }
    }
}
