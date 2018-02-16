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
    public delegate void UpdateValue(object sender, RoutedEventArgs e);
    /// <summary>
    /// Interaction logic for NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        public event UpdateValue ValueChanged;
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Value
        {
            get
            {
                return Convert.ToInt32(txtValue.Text);
            }
            set
            {
                txtValue.Text = value.ToString();
                ValueChanged?.Invoke(this, new RoutedEventArgs());
            }
        }

        public NumericUpDown()
        {            
            InitializeComponent();
            Minimum = 0;
            Maximum = 100;
            Value = 0;
        }

        

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            if (Value + 1 <= Maximum) Value += 1;
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            if (Value - 1 >= Minimum) Value -= 1;
        }
    }
}
