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
using ReisekatologLib;

namespace ReisezieleWPF
{
    /// <summary>
    /// Interaction logic for AnzeigeHotels.xaml
    /// </summary>
    public partial class AnzeigeHotels : Window
    {
        public AnzeigeHotels(string land, string ort)
        {
            InitializeComponent();
            DataContext = new Katalog().HotelsInZiel(land, ort);
        }
    }
}
