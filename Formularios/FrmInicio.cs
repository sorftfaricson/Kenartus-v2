using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kenartus.Formularios
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            if(TxtUsuario.Text == "eric" && TxtContrasena.Text == "1234")
            {
                this.Hide();
                Formularios.FrmMenuPrincipal z = new Formularios.FrmMenuPrincipal();
                z.ShowDialog();

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos, \n intentalo nuevamente");
            }
        }
    }
}
