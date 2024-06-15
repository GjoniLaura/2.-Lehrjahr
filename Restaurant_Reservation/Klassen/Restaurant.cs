﻿using System;
using System.Collections.Generic;

namespace Restaurant_Reservation.Klassen
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public int Valuation { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public string Cuisine { get; set; }

        // Maintains count of tables by capacity
        public Dictionary<int, int> TableCapacities { get; set; } = new Dictionary<int, int>();

    }

    public class Location
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
