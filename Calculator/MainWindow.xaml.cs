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
            Expression_TextBox.Text = e.Key.ToString();
            if (InputLanguageManager.Current.CurrentInputLanguage.TwoLetterISOLanguageName == "ru")
            {
                if (e.Key == Key.OemQuestion)
                {
                    Expression_TextBox.Text = ",";
                }

                if ((e.Key == Key.Oem5) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                {
                    Expression_TextBox.Text = "/";
                }

                if ((e.Key == Key.D6) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                {
                    Expression_TextBox.Text = "^";
                }
            }

            else if (InputLanguageManager.Current.CurrentInputLanguage.TwoLetterISOLanguageName == "en")
            {
                if (e.Key == Key.OemComma)
                {
                    Expression_TextBox.Text = ",";
                }

                if (e.Key == Key.OemPeriod)
                {
                    Expression_TextBox.Text = ",";
                }

                if (e.Key == Key.OemQuestion)
                    Expression_TextBox.Text = "/";
            }
            
            if ((e.Key == Key.D1) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                Expression_TextBox.Text = "!";
            }

            if ((e.Key == Key.D8) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                Expression_TextBox.Text = "*";
            }

            if ((e.Key == Key.D9) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                Expression_TextBox.Text = "(";
            }

            if ((e.Key == Key.D0) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                Expression_TextBox.Text = ")";
            }

            if ((e.Key == Key.OemMinus) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                Expression_TextBox.Text = "-";
            }

            if ((e.Key == Key.OemPlus) && 
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                Expression_TextBox.Text = "+";
            }

            if (e.Key == Key.Enter)
            {
                Expression_TextBox.Text = "=";
            }

            if (e.Key == Key.Back)
            {
                Expression_TextBox.Text = "Backspace";
            }
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
