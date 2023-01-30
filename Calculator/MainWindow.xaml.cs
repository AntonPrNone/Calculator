using Logic_Calc;
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

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Key keyOld;
        Key keyNew;
        Logic logic = new Logic();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = e.Source as Button;
            var text = btn.Content;
            Expression_TextBox.Text = (string)text;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            keyOld = keyNew;
            keyNew = e.Key;
            if (keyOld == Key.LeftShift && keyNew == Key.OemPlus)
            Expression_TextBox.Text = e.Key.ToString();

            Logic.ProcessingKey(e.Key, false);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radio = e.Source as RadioButton;
            switch (radio.Content)
            {
                case "Degrees":
                    logic.cornerType = Logic.Corner.Degrees; 
                    break;

                case "Radians":
                    logic.cornerType = Logic.Corner.Radians;
                    break;

                case "Grads":
                    logic.cornerType = Logic.Corner.Grads;
                    break;
            }
            if (IsInitialized)
            Expression_Label.Content = logic.cornerType;

        }
    }
}
