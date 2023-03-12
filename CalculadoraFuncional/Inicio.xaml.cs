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

namespace CalculadoraFuncional
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();
            Closing += OnClosing;
        }
        /*ESTE METODO ES EL QUE ACTIVA LA CALCUADORA A SER MOSTRADA*/
        private void Inicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw=new MainWindow();
            mw.Show();
            this.Hide();

        }

        /*ESTE METODO SIMPLEMENTE ES UNA ALERTA QUE A FUTURO ME GUSTARIA METELE SONIDO*/
        private void Ayuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Esta Aplicacion es una calculadora pero con Bendicion", "Ayudsa Calculadora", MessageBoxButton.OKCancel);

        }
        /*ESTE ES UN METODO PARA SALIR DEL PROGRAMA*/
        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        /*ESTE ES UN METODO PARA SALIR DEL PROGRAMA*/
        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
