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
    //wir definieren einen Delegaten zum Event 
    public delegate void CollectData(String size, List<String> belag);

    /// <summary>
    /// Interaktionslogik für FormInline.xaml
    /// </summary>
    public partial class FormInline : Window
    {
        //das Formular stellt einen Event bereit, bei welchem eine Methode ausgeführt werden könnte
        public event CollectData Collect; 

        public FormInline()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            //Daten sammeln aus der ComboBox, aus den Checkboxen
            String size = "Mittel";
            List<String> belag = new List<String>();
            belag.Add("Salami");
            belag.Add("Schokolade");
            belag.Add("Honig");

            if(Collect != null) Collect(size, belag);

            //zurücksetzen der Eingaben oder Schließen Fenster 
        }
    }
}
