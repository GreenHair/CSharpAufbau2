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
using ReisekatologLib;

namespace ReisezieleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Katalog kat = new Katalog();
            InitializeComponent();

            DataContext = kat.AlleZiele();
        }

        private void cmbZiel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = cmbZiel.SelectedIndex;
            lstCity.Items.Clear();
            lstCity.Items.Add(new Katalog().AlleZiele()[index].Ort);
        }

        private void lstZiele_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstZiele.SelectedIndex;
            Reiseziel ziel = new Katalog().AlleZiele()[index];
            AnzeigeHotels window = new AnzeigeHotels(ziel.Land, ziel.Ort);
            window.ShowDialog();
        }
    }
}
