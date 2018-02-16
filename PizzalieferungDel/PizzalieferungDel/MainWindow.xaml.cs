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
using LibPizzalieferung;

namespace PizzalieferungDel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Lieferdienst ld = new Lieferdienst();

        public MainWindow()
        {
            InitializeComponent();
           
        }
        

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Bestellformular Form = new Bestellformular(ld.Groessen);
            Form.BestellungAbschicken += Form_BestellungAbschicken;
            Form.Show();
        }

        private void Form_BestellungAbschicken(Pizza p, int anz, double preis)
        {
            p.Fertig = false;
            for(int i = 0; i < anz; i++)
            {
                ld.Bestellen(p);
                ld.Umsatz += preis;
            }
            lstBestellungen.ItemsSource = ld.Bestellungen;
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
