using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker
{
    internal class Phone : IDevice
    {
        public Phone( string office, string brand, string model, DateOnly purchaseDate, decimal priceUSD)
        {
            //Enum in IDevice.cs
            Type = DeviceType.Phone;

            Office = office;
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            PriceUSD = priceUSD;
        }

        public DeviceType Type
        { get; }

        public string Office
        { get; }

        public string Brand
        { get; }

        public string Model
        { get; }

        public DateOnly PurchaseDate
        { get; }

        public decimal PriceUSD
        { get; }
    }
}
