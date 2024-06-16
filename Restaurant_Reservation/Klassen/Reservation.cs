using Newtonsoft.Json;
using System;

namespace Restaurant_Reservation.Klassen
{
    public class Reservation
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Restaurant Restaurant { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Numpeople { get; set; }

        public Reservation(User user, Restaurant restaurant, DateTime start, DateTime end, int numPeople)
        {
            User = user;
            Restaurant = restaurant;
            Start = start;
            End = end;
            Numpeople = numPeople;
        }
    }

}
