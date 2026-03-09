using Kenartus.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kenartus.Clases
{
    internal class ClaseInicial
    {
        [STAThread]
        public static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmPortada());

            Formularios.FrmPortada x = new Formularios.FrmPortada();
            x.ShowDialog();

        }
    }
}
