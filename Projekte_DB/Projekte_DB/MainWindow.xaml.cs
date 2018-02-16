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
using ProjekteLib;

namespace Projekte_DB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Datenbank myDB = new Datenbank();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = myDB;
            lstBox.ItemsSource = myDB.GetAbteilungen();
            cmbProj.ItemsSource = myDB.AlleProjekte();
            cmbPersonal.ItemsSource = myDB.GetPersonal();
            cmbProjekt.ItemsSource = myDB.AlleProjekte();
        }

        private void cmbProj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int proj_id = cmbProj.SelectedIndex + 1;
            int std = myDB.GetStunden(proj_id);
            lblStunden.Content = "Stunden: " + std;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(cmbPersonal != null && cmbProjekt != null)
            {
                Projekt proj = cmbProjekt.SelectedItem as Projekt;
                Personal pers = cmbPersonal.SelectedItem as Personal;
                myDB.Eintragen(proj.Id, pers.Id, nudStd.Value);
            }
        }
    }
}
