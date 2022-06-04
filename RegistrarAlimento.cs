using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafetería_Luna
{
    public partial class RegistrarAlimento : Form
    {
        public RegistrarAlimento()
        {
            InitializeComponent();
        }

        private void IconCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Length == 0 || txtPrecio.Text.Length == 0)
            {
                MessageBox.Show("Error. No se han llenado uno o más campos obligatorios.");
            }
            else if((radioActivo.Checked == false && radioInactivo.Checked == false) || 
                (radioBCaliente.Checked == false && radioBFria.Checked == false && radioComida.Checked == false))
            {
                MessageBox.Show("Error. No se han llenado uno o más campos obligatorios.");
            }
            else
            {
                claseAlimento alimento = new claseAlimento();

                alimento.id_alimento = Funciones.codigoAlimento();

                alimento.nombre_alimento = txtNombre.Text;

                if (radioBCaliente.Checked == true)
                {
                    alimento.tipo_alimento = "Bebida Caliente";
                }
                else if(radioBFria.Checked == true)
                {
                    alimento.tipo_alimento = "Bebida Fria";
                }
                else if(radioComida.Checked == true)
                {
                    alimento.tipo_alimento = "Comida";
                }

                alimento.precio_alimento = Convert.ToDouble(txtPrecio.Text.ToString());

                alimento.descripcion_alimento = txtDescripcion.Text;

                if(radioActivo.Checked == true)
                {
                    alimento.estado_alimento = 1;
                }
                else if(radioInactivo.Checked == true)
                {
                    alimento.estado_alimento = 0;
                }

                int retorno = Funciones.RegistarAlimento(alimento);
                if(retorno > 0)
                {
                    MessageBox.Show("Alimento registrado.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar el alimento");
                }
            }
        }

        private void RegistrarAlimento_Load(object sender, EventArgs e)
        {

        }
    }
}
