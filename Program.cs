using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace AssetTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Office Sweden = new Office("Sweden", "SEK");
            Office Germany = new Office("Germany", "EUR");
            Office Denmark = new Office("Denmark", "DKK");

            List<Office> Offices = [ 
                Sweden, 
                Germany, 
                Denmark 
            ];


            Sweden.Add(new Phone("Sweden", "Apple", "iPhone", new DateOnly(2024, 10, 11), 943));
            Sweden.Add(new Phone("Sweden", "Car", "iPhone", new DateOnly(2026, 09, 11), 943));
            Sweden.Add(new Phone("Sweden", "Nokia", "iPhone", new DateOnly(2023, 06, 05), 943));
            Sweden.Add(new Phone("Sweden", "Apple", "iPhone", new DateOnly(1992, 1, 11), 943));
            Sweden.Add(new Phone("Sweden", "Fläskfilé", "iPhone", new DateOnly(2020, 12, 11), 943));
            Sweden.Add(new Phone("Sweden", "Apple", "iPhone", new DateOnly(2021, 12, 11), 943));

            Sweden.Add(new Computer("Sweden", "Apple", "iMac", new DateOnly(2021, 12, 11), 943));
            Sweden.Add(new Computer("Sweden", "Samsung", "KomPUtor", new DateOnly(2022, 12, 11), 943));
            Sweden.Add(new Computer("Sweden", "Acer", "Aspire", new DateOnly(2023, 12, 11), 943));
            Sweden.Add(new Computer("Sweden", "Asus", "Thinkpad", new DateOnly(2024, 12, 11), 943));

            Offices[0].List();

            //StringComparison compareIgnoreCase = StringComparison.OrdinalIgnoreCase;


            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nAsset Tracker");
            Console.WriteLine(">Main Commands:\n" +
                "'add' to add new equipment\n" +
                "'list' to display offices\n" +
                "'remove' to remove equipment\n" +
                "" +
                "'quit' to exit the program.");

            string? input;
            Console.WriteLine("\nOffice locations:");
            foreach (var location in Offices)
            {
                Console.WriteLine($"  {location.Country}");
            }

            do 
            {
                Console.Write("\n>Main Command: ");
                input = Console.ReadLine().Trim();

                switch (input.ToLower())
                {
                    case "quit": //Exit main loop
                        break;

                    case "add":
                        Offices = DeviceManager.New(Offices);
                        break;

                    case "list":

                        break;

                    case "remove":
                        //Offices = DeviceManager.Remove(Offices);
                        break;

                    default: 
                        Console.WriteLine("Input not recognized.");
                        Console.WriteLine("Commands: 'add' 'list' 'remove' 'quit'");
                        break;
                }
            } 
            //Loop end
            while (input != "quit");
        }
    }
}
