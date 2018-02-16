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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bibo;

namespace Pizzalieferung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Lieferdienst ld;

        public MainWindow()
        {
            InitializeComponent();
            ld = new Lieferdienst();
            ld.bestellen(new Pizza{Size="Klein", Belag = new String[]{"Salami","Käse"}.ToList(), Fertig = true, Sonder=""});
            ld.bestellen(new Pizza{Size="Mittel", Belag = new String[]{"Ananas","Schinken","Peperoni"}.ToList(), Fertig=false, Sonder=""});
            ld.bestellen(new Pizza{Size="Klein", Belag = new String[]{"Feige", "Honig"}.ToList(), Fertig=true, Sonder=""});

            this.DataContext = ld.getAlle();
            label2.DataContext = ld.getUmsatz();

            //Eine Methode soll parallel ausgeführt werden
            System.Threading.Thread clock = new System.Threading.Thread(ticktack);
          //  clock.Start();

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            FormInline wind = new FormInline();

            //wir schauen, was das FormularInline an Events bietet
            //wind_collect ist eine Methode, die dem Delegaten entspricht 
            wind.Collect += wind_collect;
            wind.Show();
        }

        //Übergabeparameter und Rückgabetyp werden vom Delegaten aus FormInline vorgegeben 
        private void wind_collect(String size, List<String> belag)
        {
            ld.bestellen(new Pizza { Size = size, Belag = belag, Fertig = false });
            this.DataContext = ld.getAlle();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            FormPage wind = new FormPage(ld.getSizes());
            wind.Order += new OrderData(wind_Order);
            wind.Show();
        }

        private double wind_Order(String size, List<String> belag, String sonder)
        {
            double result =  ld.bestellen(new Pizza{Size = size, Belag = belag, Fertig = false, Sonder = sonder});
            this.DataContext = ld.getAlle();
            label2.DataContext = ld.getUmsatz();
            return result;
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            FormSite wind = new FormSite();
            wind.Show();
        }

    
        //eine Methode, die parallel in einem eigenen Thread ausgeführt wird und die Zeit in Sek hochzählt
        //und in einem Label anzeigt
        private void ticktack()
        {
            int sec = 0;
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                sec++;
                //label1 ist ein Element, das zu einem anderen Thread gehört 
                //das MainWindow verweigert diesem Thread den direkten Zugriff auf das Label
                //label1.Content = "" + sec;
                //wir arbeiten mit Delegaten
                //wir übermitteln DIESEM Thread eine Methode aus dem MainWindow-Thread, die ausgeführt werden soll 
                //this ist das Objekt von MainWindow, und dieses Objekt erlaubt einem anderen Thread (ticktack)
                //das eine MEthode ausgeführt werden kann 
                //Invoke verlangt eine Methode, die dem Delegaten Action gerecht wird
                //ein Delegate ist ein Typ - hat einen Konstruktor, der einen Methode übernimmt 
                this.Dispatcher.Invoke(new Action(
                    () =>
                    {
                        label1.Content = "" + sec;
                    }
                ));
            }
        }

        private void lstBestellung_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((Pizza)lstBestellung.Items[lstBestellung.SelectedIndex]).Fertig = true;
            this.DataContext = ld.getAlle();
            label2.DataContext = ld.getUmsatz();
        }
        
    }
}
