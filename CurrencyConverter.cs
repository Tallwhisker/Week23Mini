﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace AssetTracker
{
    static class CurrencyConverter
    {
        static private string xmlUrl = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
        static private string localUrl = @"C:\Users\kevin\Downloads\eurofxref-daily-1.xml";
        static Envelope envelope = CurrencyConverter.Update();


        static public decimal ConvertTo(decimal value, string currency, out decimal newValue)
        {
            newValue = -1;

            //Make USD currency input to EURO
            foreach (var cube in envelope.Cube.Cube1.Cube)
            {
                if (cube.currency == "USD")
                {
                    newValue = value / cube.rate;
                    break;
                }
            }

            if (currency == "EUR")
            {
                return newValue;
            }


            //Find and convert to input currency
            foreach (var cube in envelope.Cube.Cube1.Cube)
            {
                if (cube.currency == currency) 
                {
                    newValue *= cube.rate;
                }
            }

            return newValue;
        }

        static public Envelope Update() 
        {
            try 
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
                XmlReader xmlReader = XmlReader.Create(localUrl);
                using (xmlReader)
                {
                    envelope = (Envelope)(serializer.Deserialize(xmlReader));
                }
                return envelope;
            } 
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return new Envelope();
            }
        }
    }
}
