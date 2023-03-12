using System;
using System.Drawing;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Xceed.Wpf.Toolkit.Core.Converters;
using Color = System.Windows.Media.Color;

namespace CalculadoraFuncional
{
    public partial class MainWindow : Window
    {
        private double lastNumber;
        private double result;
        private bool isNewNumber = true;
        private string currentOperator;
        private int firstNumber;
        private readonly int secondNumber;
        private void SetButtonBackgroundColor(Button button)
        {
            ConfiguracionCalculadora.LeerXML();

            // Obtener el color de fondo del archivo de configuración
            string colorString = ConfiguracionCalculadora.colorBoton;
            System.Windows.Media.Color bgColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colorString);

            // Establecer el color de fondo del botón
            button.Background = new SolidColorBrush(bgColor);
        }
        private void SetBackGroundColor(Window w1)
        {
            ConfiguracionCalculadora.LeerXML();

            // Obtener el color de fondo del archivo de configuración
            string colorString = ConfiguracionCalculadora.colorFondo;
            System.Windows.Media.Color bgColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colorString);

            // Establecer el color de fondo del botón
            w1.Background = new SolidColorBrush(bgColor);
            ButtonSettings.Background=new SolidColorBrush(bgColor);
        }
        private void darColores()
        {
            /*ESTO LO QUE HACE ES DARLE EL COLOR A TODOS LOS BOTONES SEGUN LA CONFIGURACION PREVIAMENTE GUARDADA*/
            SetButtonBackgroundColor(btnClear);
            SetButtonBackgroundColor(btnAdd);
            SetButtonBackgroundColor(btnMultiply);
            SetButtonBackgroundColor(btnDivide);
            SetButtonBackgroundColor(btnSubtract);
            SetButtonBackgroundColor(btnEqual);
            SetButtonBackgroundColor(btnZero);
            SetButtonBackgroundColor(btnOne);
            SetButtonBackgroundColor(btnTwo);
            SetButtonBackgroundColor(btnThree);
            SetButtonBackgroundColor(btnFour);
            SetButtonBackgroundColor(btnFive);
            SetButtonBackgroundColor(btnSix);
            SetButtonBackgroundColor(btnSeven);
            SetButtonBackgroundColor(btnEight);
            SetButtonBackgroundColor(btnNine);
            SetButtonBackgroundColor(ButtonDecimal);
            SetButtonBackgroundColor(ButtonMemPlusMinus);
            SetButtonBackgroundColor(ButtonPercentage);
        }
        private void ChangeAnimationColor()
            
        {
            ConfiguracionCalculadora.LeerXML();
            Color color = (Color)System.Windows.Media.ColorConverter.ConvertFromString(ConfiguracionCalculadora.colorAnimacion);

            Storyboard animation = (Storyboard)this.FindResource("FlashAnimation");
            ColorAnimation colorAnimation = (ColorAnimation)animation.Children[0];
            colorAnimation.To = color;
        }



        public MainWindow()
        {
            
            InitializeComponent();
            darColores();
            SetBackGroundColor(this);

            ChangeAnimationColor();
            Closing += MainWindow_Closing;
           
           
         

        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        { 
            Inicio i1=new Inicio();
            i1.Show();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            string digit = (string)((Button)sender).Content;
            if (isNewNumber)
            {
                txtResult.Text = digit;
                isNewNumber = false;
            }
            else
            {
                txtResult.Text += digit;
            }
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            string op = (string)((Button)sender).Content;
            if (currentOperator != null)
            {
                double newNumber = double.Parse(txtResult.Text);
                switch (currentOperator)
                {
                    case "+":
                        result += newNumber;
                        break;
                    case "-":
                        result -= newNumber;
                        break;
                    case "*":
                        result *= newNumber;
                        break;
                    case "/":
                        result /= newNumber;
                        break;
                }
                txtResult.Text = result.ToString();
            }
            else
            {
                result = double.Parse(txtResult.Text);
            }
            currentOperator = op;
            isNewNumber = true;
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {

            double newNumber = double.Parse(txtResult.Text);
            switch (currentOperator)
            {
                case "+":
                    result += newNumber;
                    break;
                case "-":
                    result -= newNumber;
                    break;
                case "*":
                    result *= newNumber;
                    break;
                case "/":
                    if (newNumber != 0)
                    {
                        result /= newNumber;
                    }
                    else
                    {
                        MessageBox.Show("No puedes dividir entre 0.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;


            }
            txtResult.Text = result.ToString();
            currentOperator = null;
            isNewNumber = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ConfiguracionCalculadora.LeerXML();
            // Realizar animación para los elementos de texto
            SolidColorBrush originalBrush = (SolidColorBrush)txtResult.Foreground;
            SolidColorBrush newBrush = new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString(ConfiguracionCalculadora.colorAnimacion));

            Storyboard storyboard = new Storyboard();
            DoubleAnimation fadeOutAnimation = new DoubleAnimation()
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromSeconds(0.5),
            };
            Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath("(UIElement.Opacity)"));
            storyboard.Children.Add(fadeOutAnimation);

            ColorAnimation changeColorAnimation = new ColorAnimation()
            {
                From = originalBrush.Color,
                To = newBrush.Color,
                Duration = TimeSpan.FromSeconds(0.5),
            };
            Storyboard.SetTargetProperty(changeColorAnimation, new PropertyPath("(TextBlock.Foreground).(SolidColorBrush.Color)"));
            storyboard.Children.Add(changeColorAnimation);

            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(0.5),
                BeginTime = TimeSpan.FromSeconds(0.5),
            };
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("(UIElement.Opacity)"));
            storyboard.Children.Add(fadeInAnimation);

            // Reiniciar valores y ejecutar la animación
            txtResult.Foreground = newBrush;
            txtResult.Opacity = 1.0;
            storyboard.Begin(txtResult);
            

            // Restablecer valores después de la animación
            // Restablecer valores después de la animación
             storyboard.Completed += (o, args) =>
             
            {
                newBrush = originalBrush;
                // Eliminar controlador de eventos
            };


            // Restablecer valores de calculadora
            txtResult.Text = "0";
            currentOperator = null;
            result = 0;
            isNewNumber = true;
        }



        private void ButtonDecimal_Click(object sender, RoutedEventArgs e)
        {
            if (!txtResult.Text.Contains(","))
            {
                txtResult.Text += ",";
            }
        }

        private void ButtonPercentage_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse(txtResult.Text);
            txtResult.Text = (number / 100).ToString();
            isNewNumber = true;
        }

        private void ButtonMemPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse(txtResult.Text);
            txtResult.Text = (-number).ToString();
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            Conf conf=new Conf();
           
            conf.Show();
            this.Hide();

        }
    }
    internal class ResultWindow
    {
        private double result;

        public ResultWindow(double result)
        {
            this.result = result;
        }
    }
}
