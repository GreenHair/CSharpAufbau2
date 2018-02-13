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
    /// Interaction logic for SuchePerson.xaml
    /// </summary>
    public partial class SuchePerson : Window
    {
        MySqlAbfragen sql;
        Person[] personen;

        public SuchePerson()
        {
            InitializeComponent();
            sql = new MySqlAbfragen("sprachquali", "root", "");
            personen = sql.AllePersonen();
            foreach (Person p in personen)
            {
                cmbNummer.Items.Add(p.Pers_nr);
            }
            //cmbNummer.Text = personen[0].Pers_nr;
            //lblName.Content = personen[0].Vorname + " " + personen[0].Nachname;

            //foreach(Sprache s in personen[0].Sprachen)
            //{
            //    lstSprachen.Items.Add(s.Welche + " " + s.Niveau);
            //}
            cmbNummer.SelectedIndex = 0;
        }

        private void btnCLose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cmbNummer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = cmbNummer.SelectedIndex;
            lblName.Content = personen[index].Vorname + " " + personen[index].Nachname;
            lstSprachen.Items.Clear();
            //lstSprachen.ItemsSource = personen[index].Sprachen;
            foreach (Sprache s in personen[index].Sprachen)
            {
                lstSprachen.Items.Add(s.Welche + " - " + s.Niveau);
            }
        }
    }
}
