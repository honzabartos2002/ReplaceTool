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

namespace ReplaceTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string obsah;
        string novyObsah;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            obsah = puvodniTextBox.Text;
            try
            {
                novyObsah = obsah.Replace(puvodniVyraz.Text, novyVyraz.Text);
            }
            catch
            {
                MessageBox.Show("Vyplňte prosím všechna pole");
            }
            novyTextBox.Text = novyObsah;
        }

        private void clipboard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(novyTextBox.Text);
            clipboard.Opacity = 0.3;
        }
        
        private void clipboard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            clipboard.Opacity = 1;
        }

        private void clipboard_MouseLeave(object sender, MouseEventArgs e)
        {
            clipboard.Opacity = 1;
        }
    }
}
