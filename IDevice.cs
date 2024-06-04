﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker
{
    public enum DeviceType
    {
        Computer,
        Phone
    }

    public interface IDevice
    {
        DeviceType Type
        { get; }

        string Office
        { get; }

        string Brand
        { get; }

        string Model
        { get; }

        DateOnly PurchaseDate
        { get; }

        decimal PriceUSD
        { get; }


    }
}
