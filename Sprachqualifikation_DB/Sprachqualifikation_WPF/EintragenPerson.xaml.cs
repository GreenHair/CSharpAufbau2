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
    /// Interaction logic for EintragenPerson.xaml
    /// </summary>
    public partial class EintragenPerson : Window
    {
        public EintragenPerson()
        {
            InitializeComponent();
        }

        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            string nummer = txtNummer.Text;
            string name = txtName.Text;
            string vorname = txtVorname.Text;
            if(nummer.Length == 0 || name.Length ==0 || vorname.Length == 0)
            {
                lblResult.Content = "Keine Daten zum Eintragen";
            }
            else
            {
                MySqlAbfragen abfrage = new MySqlAbfragen("sprachquali", "root", "");
                int ergebnis = abfrage.PersonHinzufügen(nummer, vorname, name);
                if(ergebnis == 1)
                {
                    lblResult.Content = "Person eingetragen";
                }
                else
                {
                    lblResult.Content = "Das hat nicht geklappt";
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
