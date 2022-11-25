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


        public ReplaceDTO Data { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Data = new ReplaceDTO();
            this.DataContext = Data;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (Data.IsValid)
            {
                Data.ReplaceNovyTB();

                if (Data.CopyText)
                {
                    Clipboard.SetText(Data.NovyText);
                }

                if (Data.ReplaceText)
                {
                    Data.PuvodniTB = Data.NovyTB;
                }

                if (predchoziPocetZmen != Data.PocetZmen && Data.PocetZmen != 0 && predchoziPocetZmen != 9999)
                {
                    MessageBox.Show("Došlo k jinému počtu úprav (" + Data.PocetZmen + ") než v předchozí operaci (" + predchoziPocetZmen + "). Zkontrolujte si prosím výstup.");
                }

                if (Data.PocetZmen != 0)
                {
                    predchoziPocetZmen = Data.PocetZmen;
                }
            }

        }

        private void clipboard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(Data.NovyTB);
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

        private void switchExpression_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Data.SwitchExpressions();
        }

        private void switchText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Data.SwitchTBs();
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
