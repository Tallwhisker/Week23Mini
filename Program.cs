using System.Security.Cryptography.X509Certificates;

namespace AssetTracker
{


    internal class Program
    {
        static void Main(string[] args)
        {
            Office Sweden = new Office("Sweden", "SEK");
            Office Germany = new Office("Germany", "EUR");
            Office Italy = new Office("Denmark", "DKK");

            List<Office> Offices = new List<Office>() { Sweden, Germany, Italy };

            Sweden.Add(new Phone("Sweden", "Apple", "iPhone", new DateOnly(2021, 12, 11), 943));
            Sweden.Add(new Phone("Sweden", "Car", "iPhone", new DateOnly(2021, 12, 11), 943));
            Sweden.Add(new Phone("Sweden", "Nokia", "iPhone", new DateOnly(2021, 12, 11), 943));
            Sweden.Add(new Phone("Sweden", "Apple", "iPhone", new DateOnly(1992, 1, 11), 943));
            Sweden.Add(new Phone("Sweden", "Apple", "iPhone", new DateOnly(2021, 12, 11), 943));
            Sweden.Add(new Phone("Sweden", "Apple", "iPhone", new DateOnly(2021, 12, 11), 943));
            Sweden.Add(new Phone("Sweden", "Apple", "iPhone", new DateOnly(2021, 12, 11), 943));

            Sweden.List();

            StringComparison compareIgnoreCase = StringComparison.OrdinalIgnoreCase;


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

                switch (input)
                {
                    case "quit": //Exit main loop
                        break;

                    case "add": //

                        break;

                    case "list":

                        break;

                    case "remove":

                        break;

                    default: 
                        Console.WriteLine("Input not recognized.");
                        Console.WriteLine("Commands: 'add' 'list' 'remove' 'quit'");
                        break;

                }
            } while (input != "quit");

        }
    }
}
