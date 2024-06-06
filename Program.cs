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
            //Currently implemented offices.
            Office Sweden = new Office("Sweden", "SEK");
            Office Germany = new Office("Germany", "EUR");
            Office Denmark = new Office("Denmark", "DKK");

            //Put offices in List
            List<Office> Offices = [ 
                Sweden, 
                Germany, 
                Denmark 
            ];


            Sweden.Add(new Phone("Sweden", "Apple", "iPhone", new DateOnly(2024, 10, 11), 1));
            Sweden.Add(new Phone("Sweden", "Car", "iPhone", new DateOnly(2026, 09, 11), 5));
            Sweden.Add(new Phone("Sweden", "Nokia", "iPhone", new DateOnly(2023, 06, 05), 100));
            Sweden.Add(new Phone("Sweden", "Apple", "iPhone", new DateOnly(1992, 1, 11), 200));
            Denmark.Add(new Phone("Denmark", "Fläskfilé", "iPhone", new DateOnly(2020, 12, 11), 10));
            Germany.Add(new Phone("Germany", "Apple", "iPhone", new DateOnly(2021, 12, 11), 10));

            Germany.Add(new Computer("Germany", "Apple", "iMac", new DateOnly(2021, 12, 11), 500));
            Denmark.Add(new Computer("Denmark", "Samsung", "KomPUtor", new DateOnly(2022, 12, 11), 500));
            Sweden.Add(new Computer("Sweden", "Acer", "Aspire", new DateOnly(2023, 12, 11), 500));
            Sweden.Add(new Computer("Sweden", "Asus", "Thinkpad", new DateOnly(2024, 12, 11), 943));

            //foreach (var office in Offices)
            //{
            //    office.List();
            //}


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
                Console.ResetColor();
                Console.Write("\nMain/ Command: ");
                input = Console.ReadLine().Trim();

                switch (input.ToLower())
                {
                    case "quit": //Exit main loop
                        break;

                    case "add":
                        Offices = AssetManager.New(Offices);
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
