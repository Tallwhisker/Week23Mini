using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker
{
    class Equipment
    {
        public Equipment(string type, string brand, string model, string office, DateOnly purchaseDate, decimal priceUSD, string localCurrency)
        {
            Type = type;
            Brand = brand;
            Model = model;
            Office = office;
            PurchaseDate = purchaseDate;
            PriceUSD = priceUSD;
            LocalCurrency = localCurrency;
        }

        public string Type
        { get; }

        public string Brand
        { get; }

        public string Model
        { get; }

        public string Office
        { get; }

        public DateOnly PurchaseDate
        { get; }

        public decimal PriceUSD
        { get; }

        public string LocalCurrency
        { get; }
    }
}
