using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        int predchoziPocetZmen = 9999;
        int pocetZmen = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            pocetZmen = Regex.Matches(puvodniTextBox.Text, Regex.Escape(puvodniVyraz.Text)).Count;
            try
            {
                novyTextBox.Text = puvodniTextBox.Text.Replace(puvodniVyraz.Text, novyVyraz.Text);
            }
            catch
            {
                MessageBox.Show("Vyplňte prosím všechna pole");
            }

            if (copyCheckBox.IsChecked == true)
            {
                Clipboard.SetText(novyTextBox.Text);
            }

            if(replaceCheckBox.IsChecked == true)
            {
                puvodniTextBox.Text = novyTextBox.Text;
            }
           
            if(predchoziPocetZmen != pocetZmen && pocetZmen != 0 && predchoziPocetZmen != 9999){
                MessageBox.Show("Došlo k jinému počtu úprav (" + pocetZmen + ") než v předchozí operaci (" + predchoziPocetZmen + "). Zkontrolujte si prosím výstup.");
            }

            if(pocetZmen != 0)
            {
                predchoziPocetZmen = pocetZmen;
            }
            
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

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            obsah = puvodniVyraz.Text;
            puvodniVyraz.Text = novyVyraz.Text;
            novyVyraz.Text = obsah;
        }

        private void swapText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            obsah = puvodniTextBox.Text;
            puvodniTextBox.Text = novyTextBox.Text;
            novyTextBox.Text = obsah;
        }

        private void novyVyraz_GotFocus(object sender, RoutedEventArgs e)
        {
            novyVyraz.SelectAll();
        }

        private void puvodniVyraz_GotFocus(object sender, RoutedEventArgs e)
        {
            puvodniVyraz.SelectAll();
        }
    }
}
