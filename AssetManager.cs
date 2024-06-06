using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker
{
    internal static class AssetManager
    {

        //Method to add devices to selected office.
        internal static List<Office> New(List<Office> offices)
        {

            Console.WriteLine("Select office with index.");

            ListOffices(offices);

            Console.Write("\nAdd/ Office index: ");
            bool isIndexNumber = Int32.TryParse(Console.ReadLine(), out int officeIndex);

            if ( ! isIndexNumber)
            {
                //If main input isn't a number, error and return unmodified offices list.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Index needs to be a number.");

                return offices;
            }

            string? officeCountry;
            try
            {
                officeCountry = offices[officeIndex].Country;
                Console.WriteLine($"Office selected: {officeCountry}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: Office index {officeIndex} does not exist.");
                return offices;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error processing office index.");
                Console.WriteLine(e);
                return offices;
            }

            //Inform user of currently supported devices.
            Console.WriteLine("\neCurrently supported devices:\n" +
                " Phone\n" +
                " Computer\n"
            );

            string? deviceType;
            do
            {
                Console.ResetColor();
                Console.WriteLine("Add device or type 'exit' to save.");

                Console.Write("Add/ Device Type: ");
                deviceType = Console.ReadLine().Trim();

                if (deviceType.ToLower() == "exit")
                {
                    continue;
                }

                //CheckInput returns true if string is empty or null.
                if (CheckInput(deviceType))
                {
                    Console.WriteLine("Device type can't be empty.");
                    continue;
                }


                Console.Write("Add/ Device Brand: ");
                string deviceBrand = Console.ReadLine().Trim();

                if (CheckInput(deviceBrand))
                {
                    Console.WriteLine("Device brand can't be empty.");
                    continue;
                }


                Console.Write("Add/ Device Model: ");
                string deviceModel = Console.ReadLine().Trim();

                if (CheckInput(deviceModel))
                {
                    Console.WriteLine("Device model can't be empty.");
                    continue;
                }


                DateOnly purchaseDate;
                try
                {
                    Console.Write("Add/ Purchase date YYYY-MM-DD: ");
                    purchaseDate = DateOnly.Parse(Console.ReadLine().Trim());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Date format incorrect. YYYY-MM-DD required.");
                    continue;
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Date empty. YYYY-MM-DD required.");
                    continue;
                }


                decimal devicePrice;
                try
                {
                    Console.Write("Add/ Device price in $USD: ");
                    devicePrice = Convert.ToDecimal(Console.ReadLine().Trim());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Invalid format. Numbers only");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: Price cannot exceed {Decimal.MaxValue}");
                    continue;
                }


                //Constructor for Devices, IDevice.cs also contains IENumerable for types.
                switch (deviceType.ToLower())
                {
                    case "phone":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Product added.");

                        offices[officeIndex].Add(new Phone(
                            officeCountry,
                            deviceBrand,
                            deviceModel,
                            purchaseDate,
                            devicePrice
                        ));

                        break;

                    case "computer":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Product added.");

                        offices[officeIndex].Add(new Computer(
                            officeCountry,
                            deviceBrand,
                            deviceModel,
                            purchaseDate,
                            devicePrice
                        ));

                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect device type.\n" +
                            "Currently supported:\n" +
                            "Phone\n" +
                            "Computer\n");
                        break;
                }
            }
            //End of loop condition from first input
            while (deviceType != "exit");

            //Return modified offices list.
            return offices;
        }


        internal static bool CheckInput(string input)
        {
            bool isEmpty = String.IsNullOrEmpty(input);

            if (isEmpty) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            return isEmpty;
        }


        internal static void ListOffices(List<Office> offices)
        {
            //List Offices in list with index
            int index = 0;
            Console.WriteLine("Index\tOffice\n");

            foreach (var office in offices)
            {
                Console.WriteLine($"{index}\t{office.Country}");
                index++;
            }
        }

        internal static void ListDevices(List<Office> offices)
        {
            Console.WriteLine("\nSelect office with index or type 'all' to list all.");

            ListOffices(offices);

            Console.Write("\nList/ Office index or 'all': ");
            string input = Console.ReadLine().Trim();
            bool isIndexNumber = Int32.TryParse(input, out int officeIndex);

            if (input.ToLower() == "all")
            {
                foreach (var office in offices)
                {
                    office.List();
                }
            }
            else if (!isIndexNumber)
            {
                //If main input isn't a number, error and return unmodified offices list.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Index needs to be a valid number or 'all'.");
            }
            else
            {
                try
                {
                    //Office prints its own devices with title
                    offices[officeIndex].List();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: Office index {officeIndex} does not exist.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unknown error processing office index.");
                    Console.WriteLine(e);
                }
            }
        }

        internal static List<Office> RemoveDevice(List<Office> offices) 
        {
            Console.WriteLine("Select office with index.");

            ListOffices(offices);

            Console.Write("\nRemove/ Office index: ");
            bool isIndexNumber = Int32.TryParse(Console.ReadLine(), out int officeIndex);

            if (!isIndexNumber)
            {
                //If main input isn't a number, error and return unmodified offices list.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Index needs to be a number.");

                return offices;
            }

            string? officeCountry;
            try
            {
                officeCountry = offices[officeIndex].Country;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: Office index {officeIndex} does not exist.");
                return offices;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error processing office index.");
                Console.WriteLine(e);
                return offices;
            }

            string? input;
            do
            {
                Console.ResetColor();
                offices[officeIndex].List();

                Console.WriteLine("\nSelect device with index or 'exit' to save");
                Console.Write("Remove/ Device index: ");

                input = Console.ReadLine().Trim();
                isIndexNumber = Int32.TryParse(input, out int deviceIndex);

                if (input.ToLower() == "exit")
                {
                    return offices;
                }

                if (!isIndexNumber)
                {
                    //If main input isn't a number, error and return unmodified offices list.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Index needs to be a number.");

                    return offices;
                }

                offices[officeIndex].Remove(deviceIndex);

            }
            while (input != "exit");

            //Return modified List
            return offices;
        }
    }
}
