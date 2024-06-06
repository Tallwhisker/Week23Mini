using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker
{
    internal class Office
    {
        internal Office(string country, string currency)
        {
            Currency = currency;
            Country = country;
            Assets = [];
            SortedList = [];
        }
        public string Currency
        { get; }

        public string Country
        { get; }

        private List<IDevice> Assets;

        private List<IDevice> SortedList;


        public void List() 
        {
            Console.WriteLine($"\nAssets of {this.Country} office:");
            Console.WriteLine($"" +
                $"Office".PadRight(10) +
                $"Type".PadRight(15) +
                $"Brand".PadRight(15) +
                $"Model".PadRight(15) +
                $"Purchase Date".PadRight(20) +
                $"Price USD".PadRight(15) +
                $"Price {this.Currency}"
            );


            foreach (var item in Assets)
            {
                //Get PurchaseDate and add 3 years for End-of-life
                DateTime itemDate = DateTime.Parse(item.PurchaseDate.ToString());
                itemDate.AddYears(3);
                TimeSpan diff = itemDate - DateTime.Now;

                CurrencyConverter.ConvertTo(item.PriceUSD, this.Currency, out decimal localPrice);

                if (diff.Days < 90)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (diff.Days < 180)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"" +
                    $"{item.Office, -10}" +
                    $"{item.Type, -15}" +
                    $"{item.Brand, -15}" +
                    $"{item.Model, -15}" +
                    $"{item.PurchaseDate, -20}" +
                    $"${item.PriceUSD, -14}" +
                    $"{Math.Round(localPrice)}"
                );

                Console.ResetColor();
            }
        }


        public void Add(IDevice item)
        {
            this.Assets.Add(item);

            this.Assets = this.Assets.OrderBy(x => x.Type)
                .ThenBy(x => x.PurchaseDate).ToList();
        }


        public void Remove(int index)
        {
            this.Assets.RemoveAt(index);
        }
    }
}
