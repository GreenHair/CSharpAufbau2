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
using SprachqualiLib;

namespace Sprachqualifikation_WPF
{
    /// <summary>
    /// Interaction logic for AllePersonen.xaml
    /// </summary>
    public partial class AllePersonen : Window
    {
        Person[] Personen;
        int index;

        public AllePersonen()
        {
            InitializeComponent();
            Personen = new MySqlAbfragen("sprachquali", "root", "").AllePersonen();

            txtNummer.Text = Personen[0].Pers_nr;
            txtName.Text = Personen[0].Nachname;
            txtVorname.Text = Personen[0].Vorname;
        }

        private void btnVor_Click(object sender, RoutedEventArgs e)
        {
            if(index < Personen.Length - 1)
            {
                index++;
                txtNummer.Text = Personen[index].Pers_nr;
                txtName.Text = Personen[index].Nachname;
                txtVorname.Text = Personen[index].Vorname;
            }
        }

        private void btnzurück_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                txtNummer.Text = Personen[index].Pers_nr;
                txtName.Text = Personen[index].Nachname;
                txtVorname.Text = Personen[index].Vorname;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
