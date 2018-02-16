using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pizzalieferung
{
    /// <summary>
    /// Interaktionslogik für FormPage.xaml
    /// </summary>
    /// 
    public delegate double OrderData(String size, List<String> belag, String sonder);

    public partial class FormPage : Window
    {
        public event OrderData Order;

        public FormPage(String[] content)
        {
            InitializeComponent();
            cmbSize.DataContext = content;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            int anzahl = 0;
            if (radioButton1.IsChecked == true) anzahl = 1;
            else if (radioButton2.IsChecked == true) anzahl = 2;
            else anzahl = 3;

            String size = cmbSize.Items[cmbSize.SelectedIndex].ToString();
            List<String> belag = new List<String>();
            if (chk1.IsChecked == true) belag.Add("Salami");
            if (chk2.IsChecked == true) belag.Add("Ananas");

            String sonder = txtZusatz.Text;

            double gesamt = 0;
            for (int i = 0; i < anzahl; i++)
            {
                if (Order != null)
                {
                    double result = Order(size, belag, sonder);
                    gesamt += result;
                }
            }
            preis.Content = "" + gesamt;
        }
    }
}
