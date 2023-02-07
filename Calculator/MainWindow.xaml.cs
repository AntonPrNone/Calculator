using Logic_Calc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (double.TryParse((string)text, out double figure))
                logic.ProcessingKey(double.Parse((string)text));
            else if ((string)text == ",")
                logic.ProcessingKey(Char.Parse((string)text));
            else logic.ProcessingKey((string)text);

            Expression_Label.Content = logic.Expression.ToString();
            Expression_TextBox.Text = logic.LastNumber.ToString();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Expression_TextBox.Text = e.Key.ToString();
            if (InputLanguageManager.Current.CurrentInputLanguage.TwoLetterISOLanguageName == "ru")
            {
                if (e.Key == Key.OemQuestion)
                    logic.ProcessingKey(",");

                if ((e.Key == Key.Oem5) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                    logic.ProcessingKey("/");
            }

            else if (InputLanguageManager.Current.CurrentInputLanguage.TwoLetterISOLanguageName == "en")
            {
                if (e.Key == Key.OemComma)
                    logic.ProcessingKey(",");

                if (e.Key == Key.OemPeriod)
                    logic.ProcessingKey(",");

                if (e.Key == Key.OemQuestion)
                    logic.ProcessingKey("/");

                if ((e.Key == Key.D6) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                    logic.ProcessingKey("^");
            }
            
            if ((e.Key == Key.D1) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                logic.ProcessingKey("!");

            if ((e.Key == Key.D5) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                logic.ProcessingKey("Mod");

            if ((e.Key == Key.D8) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                logic.ProcessingKey("*");

            if ((e.Key == Key.D9) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                logic.ProcessingKey("(");

            if ((e.Key == Key.D0) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                logic.ProcessingKey(")");

            if ((e.Key == Key.OemMinus) &&
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                logic.ProcessingKey("-");

            if ((e.Key == Key.OemPlus) && 
                (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                logic.ProcessingKey("+");

            else if (e.Key == Key.Enter || e.Key == Key.OemPlus)
                logic.ProcessingKey("=");

            if (e.Key == Key.Back)
                logic.ProcessingKey("⟵");

            if (e.Key == Key.Escape)
                logic.ProcessingKey("CE");

            if ((e.Key.ToString().Length == 2 && e.Key.ToString()[0] == 'D' 
                && int.TryParse(e.Key.ToString()[1].ToString(), out int figure)) )
                logic.ProcessingKey(Int32.Parse(e.Key.ToString()[1].ToString()));

            Expression_Label.Content = logic.Expression.ToString();
            Expression_TextBox.Text = logic.LastNumber.ToString();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radio = e.Source as RadioButton;
            switch (radio.Content)
            {
                case "Degrees":
                    logic.СornerType = Logic.Corner.Degrees; 
                    break;

                case "Radians":
                    logic.СornerType = Logic.Corner.Radians;
                    break;

                case "Grads":
                    logic.СornerType = Logic.Corner.Grads;
                    break;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://youtu.be/o-YBDTqX_ZU");
        }
    }
}
