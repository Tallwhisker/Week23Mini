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
            Console.WriteLine($"\nAssets of {this.Country} office.");
            Console.WriteLine($"" +
                $"Office\t" +
                $"Type\t\t" +
                $"Brand\t\t" +
                $"Model\t\t" +
                $"Purchase Date\t" +
                $"Price USD\t" +
                $"Price {this.Currency}"
            );


            foreach (var item in Assets)
            {
                //Get PurchaseDate and add 3 years for End-of-life
                DateTime itemDate = DateTime.Parse(item.PurchaseDate.ToString());
                itemDate.AddYears(3);
                TimeSpan diff = itemDate - DateTime.Now;
                Console.WriteLine($"{diff.Days}");

                if (diff.Days < 90)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (diff.Days < 180)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"" +
                    $"{item.Office}\t" +
                    $"{item.Type}\t\t" +
                    $"{item.Brand}\t\t" +
                    $"{item.Model}\t\t" +
                    $"{item.PurchaseDate}\t" +
                    $"{item.PriceUSD}\t" +
                    $"{item.PriceUSD}"
                );

                Console.ResetColor();
            }
        }


        public void Add(IDevice item)
        {
            this.Assets.Add(item);

            this.Assets = this.Assets.
                OrderBy(x => x.Type).
                ThenBy(x => x.PurchaseDate).
                ToList();
        }


        public void Remove(int index)
        {
            this.Assets.RemoveAt(index);
        }
    }
}
