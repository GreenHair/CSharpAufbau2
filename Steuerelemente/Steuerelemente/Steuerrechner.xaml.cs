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

namespace Steuerelemente
{
    /// <summary>
    /// Interaction logic for Steuerrechner.xaml
    /// </summary>
    public partial class Steuerrechner : UserControl
    {
        public double Brutto
        {
            get
            {
                return Convert.ToDouble(txtBrutto.Text);
            }
            set
            {
                if(txtBrutto != null) txtBrutto.Text = value.ToString();
            }
        }

        public static DependencyProperty NettoProperty = DependencyProperty.Register("Netto", typeof(double), typeof(Steuerrechner));
        public double Netto
        {
            get
            {
                return (double)GetValue(NettoProperty);
            }
            set
            {
                SetValue(NettoProperty, value);
            }
        }

        public Steuerrechner()
        {
            InitializeComponent();
            txtNetto.DataContext = this;
        }

        private void r1_Checked(object sender, RoutedEventArgs e)
        {
            Brutto = Netto * 1.07;
        }

        private void r2_Checked(object sender, RoutedEventArgs e)
        {
            Brutto = Netto * 1.19;
        }

        private void r3_Checked(object sender, RoutedEventArgs e)
        {
            Brutto = Netto;
        }
    }
}
