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
    public partial class btnEliminarUsuario : Form
    {
        string codigo_admi;
        public btnEliminarUsuario(string nombre, string texto)
        {
            codigo_admi = texto;
            InitializeComponent();
        }

        public btnEliminarUsuario()
        {
            
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void MenuAdministrador_Load(object sender, EventArgs e)
        {

        }

        private void BtnSlide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
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

        private void IconRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconRestaurar.Visible = false;
            iconMaximizar.Visible = true;
        }

        private void IconMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconRestaurar.Visible = true;
            iconMaximizar.Visible = false;
        }

        private void AbrirFormPanel(object Formhijo)
        {
            if (this.panelControlador.Controls.Count > 0)
            {
                this.panelControlador.Controls.RemoveAt(0);
            }
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelControlador.Controls.Add(fh);
            this.panelControlador.Tag = fh;
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

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnCancelarPedido_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new CancelarPedido());
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void BtnEliminarAlimento_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new EliminarAlimento());
        }

        private void BtnModificarUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new ModificarUsuario());
        }

        private void BtnModificarAlimento_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new ModificarAlimento());
        }

        private void BtnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new RegistrarUsuario());
        }

        private void BtnRegistrarAlimento_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new RegistrarAlimento());
        }

        private void BtnEliminarU_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new EliminarUsuario());
        }

        private void BtnReporteVentas_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new ReporteVentas());
        }

        private void BtnListaAlimentos_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new ListaAlimentos());
        }

        private void BtnHistorialP_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new ListaHistorialPedidos());
        }

        private void BtnListaUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new ListaUsuarios());
        }

        private void PanelControlador_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
