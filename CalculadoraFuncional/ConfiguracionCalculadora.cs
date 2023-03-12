using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows;
using System.Xml;

namespace CalculadoraFuncional
{
     class ConfiguracionCalculadora
    {
        public static string colorBoton { get; set; } = "AquaMarine";
        public static string colorAnimacion { get; set; } = "Red";
        public static string colorFondo { get; set; } = "CornflowerBlue";
        ConfiguracionCalculadora() { }

        public static void LeerXML()
        {
            if (System.IO.File.Exists("config.xml"))
            {
                // Cargar el archivo XML
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load("config.xml");

                // Obtener los valores de tamaño, fuente y estilo de fuente del archivo XML
                XmlNode botonNode = xmlDocument.SelectSingleNode("/configuration/ColorBoton");
                XmlNode animacionNode = xmlDocument.SelectSingleNode("/configuration/ColorAnimacion");
                XmlNode fondoNode = xmlDocument.SelectSingleNode("/configuration/ColorFondo");

                // Convertir los valores de tamaño y estilo a tipos numéricos
                colorBoton = botonNode.InnerText;
                colorAnimacion = animacionNode.InnerText;

                colorFondo = fondoNode.InnerText;

            }
            else
            {

            }

        }
    }
}
