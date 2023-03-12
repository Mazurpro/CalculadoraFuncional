using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace CalculadoraFuncional
{
    /// <summary>
    /// Lógica de interacción para Conf.xaml
    /// </summary>
    public partial class Conf : Window
    {
        /*Esto son las opciones del ComboBox*/
        string[] coloresBasicos = { "Blue", "Red", "Green", "Orange", "Purple", "Yellow", "Pink", "Teal", "Gray", "Brown","Coral" };

        public Conf()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
            //Lo añado al comboBox
            for (int i = 0; i < coloresBasicos.Length; i++)
            {
                btnColorComboBox.Items.Add(coloresBasicos[i]);
                animColorComboBox.Items.Add(coloresBasicos[i]);
                screenColorComboBox.Items.Add(coloresBasicos[i]);
            }
            //Le doy valores  para que no tenga la posibilidad de ser nulo
            btnColorComboBox.SelectedIndex = 7;
            animColorComboBox.SelectedIndex = 1;
            screenColorComboBox.SelectedIndex = 8;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           MainWindow main=new MainWindow();
            main.Show();
        }

        private void btnAcept_Click(object sender, RoutedEventArgs e)
        {
            //Obtengo el valor seleccionado con los spinner
            string colorButton = (string)btnColorComboBox.SelectedItem;
            string colorAnimation = (string)animColorComboBox.SelectedItem;
            string colorBackGround = (string)screenColorComboBox.SelectedItem;

            // Crear el archivo de configuración XML
            using (XmlWriter writer = XmlWriter.Create("config.xml"))
            {
                // Escribir el encabezado del archivo XML
                writer.WriteStartDocument();

                // Escribir el elemento raíz
                writer.WriteStartElement("configuration");

                // Guardo Color Boton en el XML
                writer.WriteStartElement("ColorBoton");
                writer.WriteString(colorButton);
                writer.WriteEndElement();

                //Guardo Color animacion en el XML
                writer.WriteStartElement("ColorAnimacion");
                writer.WriteString(colorAnimation);
                writer.WriteEndElement();

                // Guardo Color fondo en el XML
                writer.WriteStartElement("ColorFondo");
                writer.WriteString(colorBackGround);
                writer.WriteEndElement();

                // Cerrar el elemento raíz
                writer.WriteEndElement();
                writer.Flush();
                MessageBox.Show("La configuracion fue guardada", "Configuracion", MessageBoxButton.OK);

                // Cerrar el archivo XML
                writer.WriteEndDocument();
                writer.Close();
                this.Close();
                


            }
        }
    }
}
