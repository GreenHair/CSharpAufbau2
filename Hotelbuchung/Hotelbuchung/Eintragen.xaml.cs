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
using System.Windows.Shapes;
using BiboHotel;

namespace Hotelbuchung
{
    /// <summary>
    /// Interaction logic for Eintragen.xaml
    /// </summary>
    public partial class Eintragen : Window
    {
        Hotel hilton;
        public Eintragen(Hotel h)
        {
            InitializeComponent();
            hilton = h;
        }

        private void btnAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length > 0 && DateVon.SelectedDate != null && DateBis.SelectedDate != null
                && cmbZimmer.SelectedItem != null)
            {
                DateTime von = (DateTime)DateVon.SelectedDate;
                DateTime bis = (DateTime)DateBis.SelectedDate;
                string name = txtName.Text;
                int nr = cmbZimmer.SelectedIndex + 1;
                hilton.eintragen(nr, name, von, bis);
                Close();
            }
            else
            {
                MessageBox.Show("Es fehlen noch wichtige Informationen!");
            }
        }
    }
}
