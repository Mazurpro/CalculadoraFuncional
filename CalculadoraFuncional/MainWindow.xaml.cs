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
        private string currentNumber = string.Empty;
        private string operation = string.Empty;
        private double firstNumber = 0.0;
        private double secondNumber = 0.0;
        private double result = 0.0;

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            string number = (sender as Button).Content.ToString();
            currentNumber += number;
            txtResult.Text = currentNumber;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                firstNumber = double.Parse(currentNumber);
                operation = (sender as Button).Content.ToString();
                currentNumber = string.Empty;
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                secondNumber = double.Parse(currentNumber);
            }

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
            currentNumber = result.ToString();
            operation = string.Empty;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = string.Empty;
            operation = string.Empty;
            firstNumber = 0.0;
            secondNumber = 0.0;
            result = 0.0;
            txtResult.Text = "0";
        }
    }

}
