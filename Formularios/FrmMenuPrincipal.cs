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
            ActualizarLista();
            IniciarFondoConexion();
            IniciarFondoControl();
            IniciarFondoDatos();
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
        private void IniciarFondoConexion()
        {
            pictureBox3.Parent = pictureBox8;
            pictureBox3.BackColor = Color.Transparent;
            label2.Parent = pictureBox8;
            label2.BackColor = Color.Transparent;

            
        }

        private void IniciarFondoControl()
        {
            label3.Parent = PbxFondo;
            label3.BackColor = Color.Transparent;
            label4.Parent = PbxFondo;
            label4.BackColor = Color.Transparent;
            label5.Parent = PbxFondo;
            label5.BackColor = Color.Transparent;
            label10.Parent = PbxFondo;
            label10.BackColor = Color.Transparent;
            label11.Parent = PbxFondo;
            label11.BackColor = Color.Transparent;
            label12.Parent = PbxFondo;
            label12.BackColor = Color.Transparent;
            label13.Parent = PbxFondo;
            label13.BackColor = Color.Transparent;
            label14.Parent = PbxFondo;
            label14.BackColor = Color.Transparent;
            pictureBox4.Parent = PbxFondo;
            pictureBox4.BackColor = Color.Transparent;

            checkBox2.Parent = PbxFondo;
            checkBox2.BackColor = Color.Transparent;
            checkBox3.Parent = PbxFondo;
            checkBox3.BackColor = Color.Transparent;
            checkBox4.Parent = PbxFondo;
            checkBox4.BackColor = Color.Transparent;

            
        }

        private void IniciarFondoDatos() 
        {
            label6.Parent = PbxFondoDatos;
            label6.BackColor = Color.Transparent;
            label7.Parent = PbxFondoDatos;
            label7.BackColor = Color.Transparent;
            label8.Parent = PbxFondoDatos;
            label8.BackColor = Color.Transparent;
            label9.Parent = PbxFondoDatos;
            label9.BackColor = Color.Transparent;
            label17.Parent = PbxFondoDatos;
            label17.BackColor = Color.Transparent;
            label18.Parent = PbxFondoDatos;
            label18.BackColor = Color.Transparent;
            pictureBox5.Parent = PbxFondoDatos;
            pictureBox5.BackColor = Color.Transparent;

            pictureBox6.Parent = PbxFondoMultimedia;
            pictureBox6.BackColor = Color.Transparent;

            pictureBox7.Parent = PbxFondoAjustesavanzados;
            pictureBox7.BackColor = Color.Transparent;

            




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
            try 
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
                        catch (Exception ex)
            {
                MessageBox.Show("¡Error! El Arduino no está conectado." + ex.Message);
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
            EnviarDatoArduino(mensaje);

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

            mensaje = numericUpDown2.Value.ToString() + "u";
            EnviarDatoArduino(mensaje);

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            mensaje = numericUpDown3.Value.ToString() + "t";
            EnviarDatoArduino(mensaje);
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


        private string carpetaPacientes = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ArchivosKenartus/Pacientes");
        private void BtnGuardarInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string nombrePaciente = TxtNombre.Text.Trim();
                string fechaLimpia = DateTime.Now.ToString("dd-MM-yyyy");


                if (string.IsNullOrEmpty(nombrePaciente))
                {
                    MessageBox.Show("Por favor, ingresa el nombre del paciente.");
                    return;
                }
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    nombrePaciente = nombrePaciente.Replace(c, '_');
                }

                // 3. Construir el nombre del archivo: "Nombre_Fecha.txt"
                string nombreArchivo = nombrePaciente + "_" + fechaLimpia + ".txt";

                // 4. Configurar rutas
                string rutaFinal = Path.Combine(carpetaPacientes, nombreArchivo);

                // 5. Crear la carpeta si no existe
                if (!Directory.Exists(carpetaPacientes)) {Directory.CreateDirectory(carpetaPacientes);}

                // 6. Formatear el contenido del archivo
                string contenido = 
                                  TxtNombre.Text + Environment.NewLine +
                                  TxtEdad.Text + Environment.NewLine +
                                  TxtPadecimiento.Text + Environment.NewLine +
                                  ComboBoxRutina.Text + Environment.NewLine +
                                  numericUpDown1.Value + Environment.NewLine +
                                  numericUpDown2.Value + Environment.NewLine +
                                  numericUpDown3.Value;

                // 7. Guardar el archivo (WriteAllText crea uno nuevo o sobrescribe si ya existe ese mismo día)
                File.WriteAllText(rutaFinal, contenido);

                MessageBox.Show($"Archivo '{nombreArchivo}' guardado con éxito en carpeta pacientes.");
                ActualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }



        }
        private void ActualizarLista()
        {
            try
            {
                listaArchivos.Items.Clear(); // Limpia la lista actual

                // Obtiene solo los nombres de archivos .txt en la carpeta
                string[] archivos = Directory.GetFiles(carpetaPacientes, "*.txt");

                foreach (string archivo in archivos)
                {
                    // Agrega solo el nombre del archivo (sin toda la ruta C:\...)
                    listaArchivos.Items.Add(Path.GetFileName(archivo));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar archivos: " + ex.Message);
            }

            try
            {
                ListRutinas.Items.Clear(); // Limpia la lista actual

                // Obtiene solo los nombres de archivos .txt en la carpeta
                string[] archivos = Directory.GetFiles(carpetaRutinas, "*.txt");

                foreach (string archivo in archivos)
                {
                    // Agrega solo el nombre del archivo (sin toda la ruta C:\...)
                    ListRutinas.Items.Add(Path.GetFileName(archivo));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar archivos: " + ex.Message);
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
            /*if (checkBox1.Checked)
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

            }*/
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

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarLista();
            MessageBox.Show("Lista de archivos actualizada.");
        }

        private void listaArchivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaArchivos.SelectedItem == null) return;
            try
            {
                string archivoSeleccionado = listaArchivos.SelectedItem.ToString();
                string rutaCompleta = Path.Combine(carpetaPacientes, archivoSeleccionado);

                if (File.Exists(rutaCompleta))
                {
                    string[] lineas = File.ReadAllLines(rutaCompleta);

                    // Asigna los valores a tus TextBox tal como lo tenías
                    if (lineas.Length >= 7)
                    {
                        TxtNombre.Text = lineas[0];
                        TxtEdad.Text = lineas[1];
                        TxtPadecimiento.Text = lineas[2];
                        ComboBoxRutina.Text = lineas[3];
                        numericUpDown1.Value = decimal.Parse(lineas[4]);
                        Thread.Sleep(10);
                        numericUpDown2.Value = decimal.Parse(lineas[5]);
                        Thread.Sleep(10);
                        numericUpDown3.Value = decimal.Parse(lineas[6]);
                        Thread.Sleep(10);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo seleccionado: " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string busqueda = textBox2.Text.ToLower().Trim();

            try
            {
                listaArchivos.Items.Clear(); // Limpiamos la lista para filtrar

                // Obtenemos todos los archivos de la carpeta
                string[] archivos = Directory.GetFiles(carpetaPacientes, "*.txt");

                foreach (string archivo in archivos)
                {
                    string nombreArchivo = Path.GetFileName(archivo);

                    // Si el nombre contiene lo que el usuario está escribiendo, lo agrega
                    if (nombreArchivo.ToLower().Contains(busqueda))
                    {
                        listaArchivos.Items.Add(nombreArchivo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar sugerencias: " + ex.Message);
            }
        }

        private void BtnYPlus_Click(object sender, EventArgs e)
        {

        }

        private void BtnW_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
        string pasos;
        private void AgregarXmas_Click(object sender, EventArgs e)
        {
            pasos = Xmas.Text + "X";
            TxtBoxContenidoRutina.AppendText(pasos + Environment.NewLine);
        }

        private void AgregarXmenos_Click(object sender, EventArgs e)
        {
            pasos = Xmenos.Text + "x";
            TxtBoxContenidoRutina.AppendText(pasos + Environment.NewLine);
        }

        private void AgregarYmas_Click(object sender, EventArgs e)
        {
            pasos = Ymas.Text + "Y";
            TxtBoxContenidoRutina.AppendText(pasos + Environment.NewLine);
        }

        private void AgregarYmenos_Click(object sender, EventArgs e)
        {
            pasos = Ymenos.Text + "y";
            TxtBoxContenidoRutina.AppendText(pasos + Environment.NewLine);
        }

        private void AgregarZmas_Click(object sender, EventArgs e)
        {
            pasos = Zmas.Text + "Z";
            TxtBoxContenidoRutina.AppendText(pasos + Environment.NewLine);
        }

        private void AgregarZmenos_Click(object sender, EventArgs e)
        {
            pasos = Zmenos.Text + "z";
            TxtBoxContenidoRutina.AppendText(pasos + Environment.NewLine);
        }


        private string carpetaRutinas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ArchivosKenartus/Rutinas");
        private void GuardarRutinasEnLista_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreRutina = TxtBoxNomRutina.Text.Trim();
                


                if (string.IsNullOrEmpty(nombreRutina))
                {
                    MessageBox.Show("Por favor, ingresa el nombre de la Rutina.");
                    return;
                }
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    nombreRutina = nombreRutina.Replace(c, '_');
                }

                // 3. Construir el nombre del archivo: "Nombre_Fecha.txt"
                string nombreArchivo = nombreRutina + ".txt";
                // 4. Configurar rutas
                string rutaFinal = Path.Combine(carpetaRutinas, nombreArchivo);

                // 5. Crear la carpeta si no existe
                if (!Directory.Exists(carpetaRutinas)) { Directory.CreateDirectory(carpetaRutinas); }

                // 6. Aqui es donde me estanque , no se como guardar el contenido del TxtBoxContenidoRutina
                string contenido = TxtBoxContenidoRutina.Text;

                // 7. Guardar el archivo (WriteAllText crea uno nuevo o sobrescribe si ya existe ese mismo día)
                File.WriteAllText(rutaFinal, contenido);

                MessageBox.Show($"Archivo '{nombreArchivo}' guardado con éxito en carpeta Rutinas.");
                ActualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ListRutinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListRutinas.SelectedItem == null) return;
            try
            {
                string archivoSeleccionado = ListRutinas.SelectedItem.ToString();
                string rutaCompleta = Path.Combine(carpetaRutinas, archivoSeleccionado);
                if (File.Exists(rutaCompleta))
                {
                    string[] lineas = File.ReadAllLines(rutaCompleta);

                    

                    // Une todas las líneas saltando de renglón y las muestra
                    TxtBoxContenidoRutina.Text = string.Join(Environment.NewLine, lineas);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo seleccionado: " + ex.Message);
            }
        }

        private void BtnActRutinas_Click(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string busqueda = textBox3.Text.ToLower().Trim();

            try
            {
                ListRutinas.Items.Clear(); // Limpiamos la lista para filtrar

                // Obtenemos todos los archivos de la carpeta
                string[] archivos = Directory.GetFiles(carpetaRutinas, "*.txt");

                foreach (string archivo in archivos)
                {
                    string nombreRutina = Path.GetFileName(archivo);

                    // Si el nombre contiene lo que el usuario está escribiendo, lo agrega
                    if (nombreRutina.ToLower().Contains(busqueda))
                    {
                        ListRutinas.Items.Add(nombreRutina);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar sugerencias: " + ex.Message);
            }
        }

        private async void BtnEnviareRut_Click(object sender, EventArgs e)
        {
            try
            {
                // 2. Separar el contenido del TextBox línea por línea
                string[] lineasDelText = TxtBoxContenidoRutina.Lines;

                foreach (string linea in lineasDelText)
                {
                    // Ignorar líneas vacías por si acaso
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    // 3. Enviar la línea completa al Arduino + un salto de línea (\n)
                    // Se usa WriteLine para que Arduino sepa exactamente dónde termina el comando
                    arduinoPort.WriteLine(linea);

                    // 4. EL RETARDO MÁGICO (No congela la pantalla)
                    // Cambia el 1000 por los milisegundos que necesites (1000 ms = 1 segundo)
                    await Task.Delay(100);
                }

                MessageBox.Show("¡Rutina enviada con éxito al Arduino!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error durante el envío: " + ex.Message);
            }
        }

        int ValorCaminadora = 0;
        private void BtnCaminadora_Click(object sender, EventArgs e)
        {
            ValorCaminadora++;
            if (ValorCaminadora == 1)
            {
                BtnCaminadora.BackColor = Color.Green;
                numericUpDown4.Enabled = true;
                numericUpDown4.Value = 10;
                mensaje = numericUpDown4.Value.ToString() + "C";
                EnviarDatoArduino(mensaje);
            }
            if (ValorCaminadora == 2)
            {
                BtnCaminadora.BackColor = Color.Transparent;
                numericUpDown4.Enabled = false;
                numericUpDown4.Value = 0;
                mensaje = numericUpDown4.Value.ToString() + "C";
                EnviarDatoArduino(mensaje);
                ValorCaminadora = 0;
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            mensaje = numericUpDown4.Value.ToString() + "C";
            EnviarDatoArduino(mensaje);
        }
    }
}
