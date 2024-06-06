using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


/* 
Device types are defined in IDevice.cs.
If updating, edit switch statement in AssetManager/Add:142
and console output in AssetManager/Add:54
 */

namespace AssetTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sample offices
            Office Sweden = new Office("Sweden", "SEK");
            Office Germany = new Office("Germany", "EUR");
            Office Denmark = new Office("Denmark", "DKK");
            Office Poland = new Office("Poland", "PLN");

            //Put offices in List
            List<Office> Offices = [ 
                Sweden, 
                Germany, 
                Denmark,
                Poland
            ];

            //Sample devices
            Sweden.Add(new Computer("Sweden", "Acer", "Aspire", new DateOnly(2021, 11, 28), 100));
            Sweden.Add(new Computer("Sweden", "Lenovo", "Thinkpad", new DateOnly(1998, 05, 15), 500));
            Sweden.Add(new Phone("Sweden", "Apple", "iPhone", new DateOnly(2024, 10, 11), 750));
            Sweden.Add(new Phone("Sweden", "Samsung", "Galaxy S20 Ultra", new DateOnly(2021, 06, 06), 945));

            Germany.Add(new Computer("Germany", "Apple", "Mac", new DateOnly(2021, 12, 19), 100));
            Germany.Add(new Computer("Germany", "Acer", "HelloThere", new DateOnly(2002, 08, 30), 500));
            Germany.Add(new Phone("Germany", "Pling", "Plong", new DateOnly(2021, 10, 11), 750));
            Germany.Add(new Phone("Germany", "Ein", "Telefon", new DateOnly(2023, 01, 11), 945));

            Denmark.Add(new Computer("Denmark", "Raspberry", "Pi6", new DateOnly(2024, 05, 20), 100));
            Denmark.Add(new Computer("Denmark", "Fractal", "UberPC", new DateOnly(2021, 12, 05), 500));
            Denmark.Add(new Phone("Denmark", "Pikachu", "IsYellow", new DateOnly(2020, 12, 11), 750));
            Denmark.Add(new Phone("Denmark", "I have", "Fun", new DateOnly(2021, 12, 05), 945));

            Poland.Add(new Computer("Poland", "The", "Mandalorian", new DateOnly(2024, 05, 20), 100));
            Poland.Add(new Computer("Poland", "Bärgar", "Berra", new DateOnly(2027, 01, 08), 500));
            Poland.Add(new Phone("Poland", "Bosch", "Indestructible", new DateOnly(2022, 01, 01), 750));
            Poland.Add(new Phone("Poland", "I like", "Cats", new DateOnly(1890, 12, 11), 945));


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ---------------------");
            Console.WriteLine("  ||  Asset Tracker  ||");
            Console.WriteLine("  ---------------------");
            Console.WriteLine(">Main Commands:\n" +
                "'add' to add new devices\n" +
                "'list' to display offices\n" +
                "'remove' to remove devices\n" +
                "'quit' to exit the program."
            );

            string? input;
            Console.WriteLine("\nOffice locations:");
            AssetManager.ListOffices(Offices);

            do 
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nMain/ Command: ");
                input = Console.ReadLine().Trim();
                Console.ResetColor();

                switch (input.ToLower())
                {
                    case "quit": //Exit main loop
                        break;

                    case "add":
                        Offices = AssetManager.NewDevice(Offices);
                        break;

                    case "list":
                        AssetManager.ListDevices(Offices);
                        break;

                    case "remove":
                        Offices = AssetManager.RemoveDevice(Offices);
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
