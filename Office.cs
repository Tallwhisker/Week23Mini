using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        }

        public string Currency
        { get; }

        public string Country
        { get; }

        private List<IDevice> Assets;


        public void List() 
        {
            Console.WriteLine($"\nDevices of {this.Country} office:");
            Console.WriteLine($"" +
                $"Index".PadRight(8) +
                $"Office".PadRight(10) +
                $"Type".PadRight(15) +
                $"Brand".PadRight(15) +
                $"Model".PadRight(15) +
                $"Purchase Date".PadRight(20) +
                $"Price USD".PadRight(15) +
                $"Local price"
            );

            int index = 0;
            foreach (var item in Assets)
            {
                //Get PurchaseDate and add 3 years for End-of-life calculation
                DateTime itemDate = DateTime.Parse(item.PurchaseDate.ToString());
                itemDate.AddYears(3);
                TimeSpan diff = itemDate - DateTime.Now;

                CurrencyConverter.ConvertTo(item.PriceUSD, this.Currency, out decimal localPrice);

                //If less than 3 months away
                if (diff.Days < 90)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                //If less than 6 months away
                else if (diff.Days < 180)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.WriteLine($"" +
                    $"{index,-8}" +
                    $"{item.Office, -10}" +
                    $"{item.Type, -15}" +
                    $"{item.Brand, -15}" +
                    $"{item.Model, -15}" +
                    $"{item.PurchaseDate, -20}" +
                    $"${item.PriceUSD, -14}" +
                    $"{this.Currency} {Math.Round(localPrice)}"
                );

                index++;
                Console.ResetColor();
            }
        }


        public void Add(IDevice item)
        {
            this.Assets.Add(item);

            //After adding new item, sort List by IENum > Date
            this.Assets = this.Assets.OrderBy(x => x.Type)
                .ThenBy(x => x.PurchaseDate).ToList();
        }


        public void Remove(int index)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            try
            {
                this.Assets.RemoveAt(index);
                Console.WriteLine($"Removed device at index [{index}] of {this.Country}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: Device index {index} does not exist.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error processing device index.");
                Console.WriteLine(e);
            }

            //After removing an item, sort List by IENum > Date
            this.Assets = this.Assets.OrderBy(x => x.Type)
            .ThenBy(x => x.PurchaseDate).ToList();
        }
    }
}
