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
using BiboHotel;

namespace Hotelbuchung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Hotel h = new Hotel();
        public MainWindow()
        {
            InitializeComponent();            
            h.eintragen(2, "Franz", new DateTime(2018, 02, 14), new DateTime(2018, 02, 15));
            h.eintragen(2, "Franz", new DateTime(2018, 02, 10), new DateTime(2018, 02, 13));
            h.eintragen(3, "Florian", new DateTime(2018, 02, 17), new DateTime(2018, 02, 18));
            h.eintragen(2, "Gertrude", new DateTime(2018, 02, 16), new DateTime(2018, 02, 19));
            h.eintragen(1, "Kees", new DateTime(2018, 02, 10), new DateTime(2018, 02, 18));
            h.eintragen(1, "Brunnhilde", new DateTime(2018, 02, 19), new DateTime(2018, 02, 24));
            h.eintragen(3, "Gisela", new DateTime(2018, 02, 14), new DateTime(2018, 02, 16));



            lstBuchung.ItemsSource = h.ausgebenAlle();
            lstZimmer.ItemsSource = h.ausgebenZimmer().Distinct();
            lstName.ItemsSource = h.ausgebenAlle().Distinct(new Vergleich()).OrderBy(b => b.Name);
        }

        private void btnNeu_Click(object sender, RoutedEventArgs e)
        {
            Eintragen ein = new Eintragen(h);
            ein.ShowDialog();
            lstBuchung.ItemsSource = h.ausgebenAlle();
            lstZimmer.ItemsSource = h.ausgebenZimmer();
            lstName.ItemsSource = h.ausgebenAlle();
        }

        private void lstZimmer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int nr = ((int)lstZimmer.SelectedItem);
            ListZimmer lz = new ListZimmer(h.ausgebenZimmerBuchung(nr));
            lz.ShowDialog();
        }

        private void lstName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = ((Buchung)lstName.SelectedItem).Name;
            ListZimmer lz = new ListZimmer(h.ausgebenNamen(name));
            lz.ShowDialog();
        }
    }
}
