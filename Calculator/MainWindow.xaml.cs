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
    }
}
