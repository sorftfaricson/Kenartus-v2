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
    public partial class FrmPortada : Form
    {
        public FrmPortada()
        {
            InitializeComponent();
            this.BackColor = Color.White;

            // 2. Hacer que ese color desaparezca
            this.TransparencyKey = Color.White;

            // 3. Quitar bordes para que parezca una portada flotante
            this.FormBorderStyle = FormBorderStyle.None;
        }

        

        private void FrmPortada_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            Formularios.FrmInicio y = new FrmInicio();
            y.ShowDialog();
            

        }
    }
}
