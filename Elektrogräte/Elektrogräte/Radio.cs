using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrogräte
{
    public class Radio:Elektrogerät
    {
        public enum Band
        {
            AM,FM
        }

        //public bool isOn { get; private set; }
        public int Volume { get; private set; }
        public double Frequenz { get; private set; }
        public Band Welle { get; private set; }
        private static Dictionary<string, double> GespeicherteSender = new Dictionary<string, double>();

        public Radio()
        {
            //isOn = false;
            Frequenz = 88.5;
            Welle = Band.FM;
        }

        public Radio(double frq)
        {
            //isOn = false;
            SetFrequency(frq);
            Welle = Band.FM;
        }

        public Radio(string sender)
        {
           // isOn = false;
            Frequenz = toFreq(sender);
            Welle = Band.FM;
        }

        public void Lauter(int wieviel)
        {
            if(Volume + wieviel <= 100)
            {
                Volume += wieviel;
            }
            else
            {
                Volume = 100;
            }
        }

        public void Leiser(int wieviel)
        {
            if(Volume - wieviel > 0)
            {
                Volume -= wieviel;
            }
            else
            {
                Volume = 0;
            }
        }

        //public string EinAus()
        //{
        //    isOn = !isOn;
        //    if (isOn)
        //    {
        //        return "Das Radio ist an";
        //    }
        //    else
        //    {
        //        return "Das Radio ist aus";
        //    }
        //}

        public void SetFrequency(double frq)
        {
            if (frq >= 88.5 && frq >= 108)
            {
                Welle = Band.FM;
                Frequenz = frq;
            }
            else
            {
                Welle = Band.AM;
                Frequenz = frq;
            }
        }

        public void setBand(Band _welle)
        {
            Welle = _welle;
        }

        public override string ToString()
        {
           // string onoff = (isOn) ? "ON" : "OFF";
            return base.ToString() + " | " + Frequenz + "mhz | "+ Welle + " | Vol. " + Volume;
        }

        public static double toFreq(string key)
        {
            return GespeicherteSender[key];
        }

        public void SenderSpeichern(string key, double value)
        {
            GespeicherteSender.Add(key, value);
        }
    }
}
