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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculadoraFuncional
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TabItem_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonDecimal_Click(object sender, RoutedEventArgs e)
        {
            if (!txtResult.Text.Contains("."))
            {
                txtResult.Text += ".";
            }
        }

        private void ButtonPercentage_Click(object sender, RoutedEventArgs e)
        {
            double value = double.Parse(txtResult.Text);
            value /= 100;
            txtResult.Text = value.ToString();
        }

        private void ButtonMemPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            double value = double.Parse(txtResult.Text);
            value *= -1;
            txtResult.Text = value.ToString();
        }
        private string number = string.Empty;
        private string operation = string.Empty;
        private double firstNumber = 0.0;
        private double secondNumber = 0.0;
        private double result = 0.0;
        private bool isDecimal = false;

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            string number = (sender as Button).Content.ToString();

            if (number == "." && txtResult.Text.Contains("."))
            {
                // No permitir agregar más de una coma
                return;
            }

            if (txtResult.Text == "0" && number != ".")
            {
                txtResult.Text = number;
            }
            else
            {
                txtResult.Text += number;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "0";
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {

            Console.Write(txtResult+"5614161146153");
            firstNumber = double.Parse(txtResult.Text);
            operation = (sender as Button).Content.ToString();
            txtResult.Text = "";
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtResult.Text))
            {
                secondNumber = double.Parse(txtResult.Text);

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by zero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                }
                txtResult.Text = result.ToString();
                firstNumber = result;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            number = string.Empty;
            operation = string.Empty;
            firstNumber = 0.0;
            secondNumber = 0.0;
            result = 0.0;
            txtResult.Text = "0";
        }
    }

}
