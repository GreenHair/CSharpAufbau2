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

namespace Sprachqualifikation_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAllePersonen_Click(object sender, RoutedEventArgs e)
        {
            AllePersonen window = new AllePersonen();
            window.ShowDialog();
        }

        private void btnNeuePerson_Click(object sender, RoutedEventArgs e)
        {
            EintragenPerson window = new EintragenPerson();
            window.ShowDialog();
        }

        private void btnSuchPerson_Click(object sender, RoutedEventArgs e)
        {
            SuchePerson window = new SuchePerson();
            window.ShowDialog();
        }
    }
}
