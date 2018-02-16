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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int index = 0;
        List<double> zahlen;
        public MainWindow()
        {
            InitializeComponent();
            zahlen = new List<double>() { 2.14, 34.45, 12.45, 1.67 };
            DataContext = zahlen[index];
        }

        private void zoom_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (rect != null)
            {
                rect.Width = zoom.Value;
                rect.Height = zoom.Value;
            }
        }

        private void btnVor_Click(object sender, RoutedEventArgs e)
        {      
            if(index < zahlen.Count -1)
            {
                DataContext = zahlen[++index];
            }
        }

        private void btnZurück_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                DataContext = zahlen[--index];
            }
        }
    }
}
