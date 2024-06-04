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

        private List<IDevice> Assets
        { get; }

        private List<IDevice> SortedList;


        public void List() 
        {
            DateTime dateTime = DateTime.Now;
            DateOnly dateToday = DateOnly.FromDateTime(dateTime);
                //new DateOnly(dateTime.Year, dateTime.Month,dateTime.Day);

            Console.WriteLine($"\nAssets of {this.Country} office.");
            Console.WriteLine($"Office\tType\tBrand\tModel\tPurchase Date\tPrice USD\tPrice {this.Currency}");
            foreach (var item in Assets)
            {
                int diff = item.PurchaseDate.Month - dateToday.Month;
                Console.WriteLine($"{diff}");
                Console.ForegroundColor = ConsoleColor.White;
                if (diff < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (diff < 6)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{item.Office}\t{item.Type}\t{item.Brand}\t{item.Model}\t{item.PurchaseDate}\t{item.PriceUSD}\t{item.PriceUSD}");
            }
        }
        public void Add(IDevice item)
        {
            this.Assets.Add(item);

            _ = this.Assets.OrderBy(x => x.Type).ThenBy(x => x.PurchaseDate);
        }

        public void Remove(int index)
        {
            this.Assets.RemoveAt(index);
        }
    }
}
