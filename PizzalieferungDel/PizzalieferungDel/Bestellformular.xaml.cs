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
using LibPizzalieferung;

namespace PizzalieferungDel
{
    /// <summary>
    /// Interaction logic for Bestellformular.xaml
    /// </summary>
    public delegate void DelBestell(Pizza p, int anz, double preis); 

    public partial class Bestellformular : Window
    {
        public event DelBestell BestellungAbschicken;

        public Bestellformular(List<string> sizes)
        {
            InitializeComponent();
            cmbSize.ItemsSource = sizes;

        }

        private void btnBestellen_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSize.SelectedItem != null)
            {
                Pizza piz = new Pizza();
                double preis = 0.0;
                switch (cmbSize.SelectedIndex)
                {
                    case 0:
                        piz.Groesse = cmbSize.SelectedItem.ToString();
                        preis = 3.5;
                        break;
                    case 1:
                        piz.Groesse = cmbSize.SelectedItem.ToString();
                        preis = 5;
                        break;
                    case 2:
                        piz.Groesse = cmbSize.SelectedItem.ToString();
                        preis = 7.5;
                        break;
                }
                foreach(CheckBox zutat in wrapBelag.Children)
                {
                    if(zutat.IsChecked == true)
                    {
                        piz.Belag.Add(zutat.Content.ToString());
                        preis += 1;
                    }
                }
                if(txtSonderwunsch.Text.Length > 0)
                {
                    piz.Belag.Add(txtSonderwunsch.Text);
                    preis += 3;
                }
                int anz = cmbAnzahl.SelectedIndex + 1;
                txtPreis.Text = (preis * anz).ToString("C");
                BestellungAbschicken(piz, anz, preis);
            }
        }
    }
}
