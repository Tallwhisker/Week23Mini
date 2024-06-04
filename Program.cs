namespace AssetTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EquipmentList assets = new EquipmentList();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nAsset Tracker");
            Console.WriteLine(">Main Commands:\n" +
                "'add' to add new equipment\n" +
                "'list' to display all equipment\n" +
                "'remove' to remove equipment\n" +
                "" +
                "'quit' to exit the program.");

            Console.Write("");
            string ?input = Console.ReadLine().Trim();

        }
    }
}
