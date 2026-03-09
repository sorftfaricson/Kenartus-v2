using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;




// ... dentro de tu clase


namespace Kenartus.Formularios
{
    public partial class FrmMenuPrincipal : Form
    {

        PrintDocument docParaImprimir = new PrintDocument();

        System.Media.SoundPlayer brillo = new System.Media.SoundPlayer(Properties.Resources.brillosound);
        SerialPort arduinoPort;




        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

            brillo.Play();
            pictureBox2.Parent = pictureBox1;
            label1.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;

            string[] puertosDisponibles = SerialPort.GetPortNames();
            CbxPuertos.Items.Clear();
            CbxPuertos.Items.AddRange(puertosDisponibles);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }




        private void BtnActPuertos_Click(object sender, EventArgs e)
        {
            string[] puertosDisponibles = SerialPort.GetPortNames();
            CbxPuertos.Items.Clear();
            CbxPuertos.Items.AddRange(puertosDisponibles);

        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                arduinoPort = new SerialPort(CbxPuertos.Text, 9600);
                arduinoPort.Open();
                MessageBox.Show("¡Conexión exitosa!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }
        }

        private void BtnDesconectar_Click(object sender, EventArgs e)
        {
            if (arduinoPort != null && arduinoPort.IsOpen)
            {
                arduinoPort.Close();
                MessageBox.Show("Desconectado.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (arduinoPort != null && arduinoPort.IsOpen)
            {
                arduinoPort.Write("p"); // Enviamos el caracter
            }
            else
            {
                MessageBox.Show("Primero debes conectarte al Arduino");
            }
        }

        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (arduinoPort != null && arduinoPort.IsOpen)
            {
                arduinoPort.Close();
            }
            else
            {

            }

        }
        //Y+
        private void BtnYPlus_MouseDown(object sender, MouseEventArgs e)
        {
            EnviarDatoArduino("e");
        }

        private void BtnYPlus_MouseUp(object sender, MouseEventArgs e)
        {
            EnviarDatoArduino("d");
        }
        //Y-
        private void BtnYMinus_MouseDown(object sender, MouseEventArgs e)
        {
            EnviarDatoArduino("f");
        }

        private void BtnYMinus_MouseUp(object sender, MouseEventArgs e)
        {
            EnviarDatoArduino("d");
        }
        //X-
        private void BtnXMinus_MouseDown(object sender, MouseEventArgs e)
        {
            EnviarDatoArduino("c");
        }

        private void BtnXMinus_MouseUp(object sender, MouseEventArgs e)
        {
            EnviarDatoArduino("a");
        }
        //X+
        private void BtnXPlus_MouseDown(object sender, MouseEventArgs e)
        {
            EnviarDatoArduino("b");
        }

        private void BtnXPlus_MouseUp(object sender, MouseEventArgs e)
        {
            EnviarDatoArduino("a");
        }
        //Z+
        private void BtnZPlus_MouseDown(object sender, MouseEventArgs e)
        {
            EnviarDatoArduino("h");
        }

        private void BtnZPlus_MouseUp(object sender, MouseEventArgs e)
        {
            EnviarDatoArduino("g");
        }
        //Z-
        private void BtnZMinus_MouseDown(object sender, MouseEventArgs e)
        {
            EnviarDatoArduino("i");
        }

        private void BtnZMinus_MouseUp(object sender, MouseEventArgs e)
        {
            EnviarDatoArduino("g");
        }






        private void EnviarDatoArduino(string datos)
        {
            // Verificamos que el objeto exista y el puerto esté abierto
            if (arduinoPort.IsOpen == true)
            {
                foreach (char c in datos)
                {
                    arduinoPort.Write(c.ToString());
                    System.Threading.Thread.Sleep(2); // opcional
                }
            }
            else
            {
                MessageBox.Show("¡Error! El Arduino no está conectado.");
            }
        }


        bool teclaPresionada = false;
        private void FrmMenuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {

            if (TabControl.SelectedIndex == 2)
            {
                //X
                if (e.KeyCode == Keys.A && !teclaPresionada)
                {
                    teclaPresionada = true;
                    EnviarDatoArduino("c");
                }
                if (e.KeyCode == Keys.D && !teclaPresionada)
                {
                    teclaPresionada = true;
                    EnviarDatoArduino("b");
                }

                //Y
                if (e.KeyCode == Keys.W && !teclaPresionada)
                {
                    teclaPresionada = true;
                    EnviarDatoArduino("e");
                }
                if (e.KeyCode == Keys.S && !teclaPresionada)
                {
                    teclaPresionada = true;
                    EnviarDatoArduino("f");
                }

                //Z
                if (e.KeyCode == Keys.O && !teclaPresionada)
                {
                    teclaPresionada = true;
                    EnviarDatoArduino("h");
                }
                if (e.KeyCode == Keys.L && !teclaPresionada)
                {
                    teclaPresionada = true;
                    EnviarDatoArduino("i");
                }
                else
                {

                }



            }


        }

        private void FrmMenuPrincipal_KeyUp(object sender, KeyEventArgs e)
        {

            if (TabControl.SelectedIndex == 2)
            {
                //X
                if (e.KeyCode == Keys.A)
                {
                    teclaPresionada = false;
                    EnviarDatoArduino("a");
                }
                if (e.KeyCode == Keys.D)
                {
                    teclaPresionada = false;
                    EnviarDatoArduino("a");
                }
                //Y
                if (e.KeyCode == Keys.W)
                {
                    teclaPresionada = false;
                    EnviarDatoArduino("d");
                }
                if (e.KeyCode == Keys.S)
                {
                    teclaPresionada = false;
                    EnviarDatoArduino("d");
                }

                //Z
                if (e.KeyCode == Keys.O)
                {
                    teclaPresionada = false;
                    EnviarDatoArduino("g");
                }
                if (e.KeyCode == Keys.L)
                {
                    teclaPresionada = false;
                    EnviarDatoArduino("g");
                }
                else
                {

                }

            }

        }
        string mensaje;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            mensaje = numericUpDown1.Value.ToString() + "v";

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

            mensaje = numericUpDown2.Value.ToString() + "u";

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            mensaje = numericUpDown3.Value.ToString() + "t";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnviarDatoArduino("1");
            System.Threading.Thread.Sleep(2);
            EnviarDatoArduino("t");
            System.Threading.Thread.Sleep(2);
            numericUpDown3.Value = 1;

            EnviarDatoArduino("1");
            System.Threading.Thread.Sleep(2);
            EnviarDatoArduino("u");
            System.Threading.Thread.Sleep(2);
            numericUpDown2.Value = 1;

            EnviarDatoArduino("1");
            System.Threading.Thread.Sleep(2);
            EnviarDatoArduino("v");
            System.Threading.Thread.Sleep(2);
            numericUpDown1.Value = 1;
            MessageBox.Show("Se han reestablecido los valores originbales de la velocidad.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void BtnGuardarInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener datos de los controles
                string nombrePaciente = TxtNombre.Text.Trim();
                // Reemplazamos caracteres que Windows no permite en nombres de archivos (como / o :)
                string fechaLimpia = dateTimePicker1.Value.ToString("dd-MM-yyyy");

                // 2. Validar que el nombre no esté vacío
                if (string.IsNullOrEmpty(nombrePaciente))
                {
                    MessageBox.Show("Por favor, ingresa el nombre del paciente.");
                    return;
                }

                // 3. Construir el nombre del archivo: "Nombre_Fecha.txt"
                string nombreArchivo = $"{nombrePaciente}_{fechaLimpia}.txt";

                // 4. Configurar rutas
                string carpeta = Path.Combine(Application.StartupPath, "Archivos");
                string rutaCompleta = Path.Combine(carpeta, nombreArchivo);

                // 5. Crear la carpeta si no existe
                if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

                // 6. Formatear el contenido del archivo
                string contenido = $"EXPEDIENTE MÉDICO{Environment.NewLine}";
                contenido += $"Fecha: {fechaLimpia}{Environment.NewLine}";
                contenido += $"Paciente: {nombrePaciente}{Environment.NewLine}";
                contenido += $"Edad: {TxtEdad.Text}{Environment.NewLine}";
                contenido += $"Padecimiento: {TxtPadecimiento.Text}{Environment.NewLine}";

                // 7. Guardar el archivo (WriteAllText crea uno nuevo o sobrescribe si ya existe ese mismo día)
                File.WriteAllText(rutaCompleta, contenido);

                MessageBox.Show($"Archivo '{nombreArchivo}' guardado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }



        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                using (OpenFileDialog buscador = new OpenFileDialog())
                {
                    string ruta = Path.Combine(Application.StartupPath, "Archivos");
                    buscador.InitialDirectory = ruta;
                    buscador.Filter = "Archivos TXT (*.txt)|*.txt";

                    if (buscador.ShowDialog() == DialogResult.OK)
                    {
                        string contenido = File.ReadAllText(buscador.FileName);

                        // IMPORTANTE: Para pasar el texto al RichTextBox desde otro hilo
                        // usamos Invoke, de lo contrario dará error de hilos.
                        RbContenido.Invoke((MethodInvoker)delegate
                        {
                            RbContenido.Text = contenido;
                        });
                    }
                }
            });

            // Configuramos el hilo como STA antes de iniciarlo
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

        }


        private void docParaImprimir_PrintPage(object sender, PrintPageEventArgs e)
        {
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {

            // 1. Guardamos el texto en una variable local ANTES de entrar al hilo
            string textoAImprimir = RbContenido.Text;

            Thread t = new Thread(() =>
            {
                try
                {
                    // Creamos un nuevo objeto de documento dentro del hilo para evitar conflictos
                    PrintDocument doc = new PrintDocument();

                    // Pasamos el texto al evento usando una expresión lambda
                    doc.PrintPage += (s, ev) =>
                    {
                        Font fuente = new Font("Arial", 12);
                        float x = ev.MarginBounds.Left;
                        float y = ev.MarginBounds.Top;
                        RectangleF area = new RectangleF(x, y, ev.MarginBounds.Width, ev.MarginBounds.Height);

                        // Usamos la variable local 'textoAImprimir'
                        ev.Graphics.DrawString(textoAImprimir, fuente, Brushes.Black, area);
                    };

                    PrintPreviewDialog vistaPrevia = new PrintPreviewDialog();
                    vistaPrevia.Document = doc;

                    // Mostramos el diálogo
                    vistaPrevia.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en impresión: " + ex.Message);
                }
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // COLORES MODO OSCURO
                this.tabPage1.BackColor = Color.Black;
                this.tabPage2.BackColor = Color.Black;
                this.tabPage3.BackColor = Color.Black;
                this.tabPage4.BackColor = Color.Black;
                this.tabPage5.BackColor = Color.Black;
                this.tabPage6.BackColor = Color.Black;
                this.ForeColor = Color.White;
            }
            else
            {
                this.tabPage1.BackColor = Color.White;
                this.tabPage2.BackColor = Color.White;
                this.tabPage3.BackColor = Color.White;
                this.tabPage4.BackColor = Color.White;
                this.tabPage5.BackColor = Color.White;
                this.tabPage6.BackColor = Color.White;
                this.ForeColor = Color.Black;

            }
        }

        private void CrearPlaylistWPL(string ruta, List<string> archivos)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"<?wpl version=""1.0""?>");
            sb.AppendLine("<smil>");
            sb.AppendLine("<body>");
            sb.AppendLine("<seq>");

            foreach (var archivo in archivos)
            {
                sb.AppendLine($@"<media src=""{archivo}"" />");
            }

            sb.AppendLine("</seq>");
            sb.AppendLine("</body>");
            sb.AppendLine("</smil>");

            File.WriteAllText(ruta, sb.ToString(), Encoding.UTF8);
        }

        private void BtnVideos_Click(object sender, EventArgs e)
        {
            string rutaConfig = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "Kenartus_videos.txt");

            string carpeta = "";

            // 🔹 leer si ya existe
            if (File.Exists(rutaConfig))
            {
                carpeta = File.ReadAllText(rutaConfig);
            }

            // 🔹 si no existe o ya no es válida → pedir carpeta
            if (string.IsNullOrEmpty(carpeta) || !Directory.Exists(carpeta))
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Selecciona la carpeta de videos";

                    if (fbd.ShowDialog() != DialogResult.OK)
                        return;

                    carpeta = fbd.SelectedPath;

                    // guardar para futuras veces
                    File.WriteAllText(rutaConfig, carpeta);
                }
            }

            // 🔹 extensiones de video
            string[] extensionesVideo =
            {
        ".mp4", ".avi", ".wmv", ".mkv", ".mov", ".mpeg"
    };

            var videos = Directory.GetFiles(carpeta)
                                  .Where(f => extensionesVideo.Contains(
                                      Path.GetExtension(f).ToLower()))
                                  .ToList();

            if (videos.Count == 0)
            {
                MessageBox.Show("No se encontraron videos en la carpeta.");
                return;
            }

            string playlistPath = Path.Combine(Path.GetTempPath(), "playlist_videos.wpl");

            CrearPlaylistWPL(playlistPath, videos);

            Process.Start(new ProcessStartInfo
            {
                FileName = playlistPath,
                UseShellExecute = true
            });
        }

        private void BtnMusica_Click(object sender, EventArgs e)
        {

            string rutaConfig = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "Kenartus_musica.txt");

            string carpeta = "";

            // 🔹 leer si ya existe
            if (File.Exists(rutaConfig))
            {
                carpeta = File.ReadAllText(rutaConfig);
            }

            // 🔹 si no existe o ya no es válida → pedir carpeta
            if (string.IsNullOrEmpty(carpeta) || !Directory.Exists(carpeta))
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Selecciona la carpeta de videos";

                    if (fbd.ShowDialog() != DialogResult.OK)
                        return;

                    carpeta = fbd.SelectedPath;

                    // guardar para futuras veces
                    File.WriteAllText(rutaConfig, carpeta);
                }
            }

            // 🔹 extensiones de video
            string[] extensionesVideo =
            {
        ".mp3", ".wav", ".wma", ".aac", ".flac"
    };

            var videos = Directory.GetFiles(carpeta)
                                  .Where(f => extensionesVideo.Contains(
                                      Path.GetExtension(f).ToLower()))
                                  .ToList();

            if (videos.Count == 0)
            {
                MessageBox.Show("No se encontraron videos en la carpeta.");
                return;
            }

            string playlistPath = Path.Combine(Path.GetTempPath(), "playlist_videos.wpl");

            CrearPlaylistWPL(playlistPath, videos);

            Process.Start(new ProcessStartInfo
            {
                FileName = playlistPath,
                UseShellExecute = true
            });
            //string[] extensionesMusica = { ".mp3", ".wav", ".wma", ".aac", ".flac" };
            //ReproducirCarpeta(extensionesMusica, "ruta_musica.txt");
        }

        private void BtnRutinaPierna_Click(object sender, EventArgs e)
        {
            EnviarDatoArduino("1");
            Thread.Sleep(1);
            EnviarDatoArduino("M");
        }

        private void BtnRutinaBrazo_Click(object sender, EventArgs e)
        {
            EnviarDatoArduino("2");
            Thread.Sleep(1);
            EnviarDatoArduino("M");
        }

        private void BtnRutinaCaminador_Click(object sender, EventArgs e)
        {
            EnviarDatoArduino("3");
            Thread.Sleep(1);
            EnviarDatoArduino("M");
        }

        private void BtnRutinaPieSentado_Click(object sender, EventArgs e)
        {
            EnviarDatoArduino("4");
            Thread.Sleep(1);
            EnviarDatoArduino("M");
        }

        private void BtnDetenerRutinas_Click(object sender, EventArgs e)
        {
            EnviarDatoArduino("0");
            Thread.Sleep(1);
            EnviarDatoArduino("M");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                EnviarDatoArduino("5");
                Thread.Sleep(1);
                EnviarDatoArduino("*");
            }
            else
            {
                EnviarDatoArduino("4");
                Thread.Sleep(1);
                EnviarDatoArduino("*");
            }
        }


        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                EnviarDatoArduino("3");
                Thread.Sleep(1);
                EnviarDatoArduino("*");
            }
            else
            {
                EnviarDatoArduino("2");
                Thread.Sleep(1);
                EnviarDatoArduino("*");
            }

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                EnviarDatoArduino("1");
                Thread.Sleep(1);
                EnviarDatoArduino("*");
            }
            else
            {
                EnviarDatoArduino("0");
                Thread.Sleep(1);
                EnviarDatoArduino("*");
            }
        }
    }
}
