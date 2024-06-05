using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker
{
    internal static class DeviceManager
    {

        //Method to add devices to selected office.
        internal static List<Office> New(List<Office> offices)
        {

            Console.WriteLine("Select office with index.");

            ListOffices(offices);

            Console.Write("\nEnter office index: ");
            bool isIndexNumber = Int32.TryParse(Console.ReadLine(), out int officeIndex);

            if (isIndexNumber)
            {
                string? officeCountry;
                try
                {
                    officeCountry = offices[officeIndex].Country;
                    Console.WriteLine($"\n Office selected: {officeCountry}");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Office index does not exist.");
                    return offices;
                }

                string? deviceType;
                do 
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Add product or type 'exit' to save.");

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
                        //purchaseDate = DateOnly.Parse(input);
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
                        //devicePrice = Convert.ToDecimal(input);
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
                //End of loop condition
                while (deviceType != "exit");

                //Return modified offices list.
                return offices;
            }
            //If main input isn't a number, error and return unmodified offices list.
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Index needs to be a number. Aborting.");

                return offices;
            }
        }

        internal static bool CheckInput(string input)
        {
            bool isEmpty = String.IsNullOrEmpty(input);

            if (isEmpty) 
            {
                Console.ForegroundColor= ConsoleColor.Red;
            }

            return isEmpty;
        }

        internal static void ListOffices(List<Office> offices)
        {
            //List Offices in list with index
            int index = 0;
            Console.WriteLine("Index\tOffice");

            foreach (var office in offices)
            {
                Console.WriteLine($"{index}\t{office.Country}");
                index++;
            }
        }

        internal static void ListDevices() { }

        //internal static List<Office> RemoveDevice(List<Office> offices) { }
    }
}
