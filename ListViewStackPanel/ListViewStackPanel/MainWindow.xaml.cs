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

namespace ListViewStackPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StackPanel stack = new StackPanel();
            for(int i = 0; i< 20; i++)
            {
                stack.Children.Add(new Label { Content = "im StackPanel" + i });
            }
            tab1.Content = stack;

            StackPanel stack2 = new StackPanel();
            for (int i = 0; i < 20; i++)
            {
                stack2.Children.Add(new Label { Content = "im StackPanel" + i });
            }
            tab2.Content = stack2;
        }
    }
}
