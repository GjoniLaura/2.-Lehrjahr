using Restaurant_Reservation.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant_Reservation.Datenbank;

namespace Restaurant_Reservation.Service
{
    public class ReservationService
    {
        private readonly DatabaseHelper _databaseHelper;

        public ReservationService(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public async Task<List<DateTime>> GetAvailableTimesAsync(Restaurant restaurant, DateTime date, int numPeople)
        {
            if (restaurant == null) return new List<DateTime>();

            var reservations = await _databaseHelper.GetReservationsForRestaurant(restaurant.Id);
            var reservedTimes = reservations
                .Where(r => r.Start.Date == date.Date)
                .Select(r => new ReservationTime { Start = r.Start, NumPeople = r.Numpeople })
                .ToHashSet();

            return GetAvailableTimesForRestaurant(restaurant, date, numPeople, reservedTimes);
        }

        private List<DateTime> GetAvailableTimesForRestaurant(Restaurant restaurant, DateTime date, int numPeople, HashSet<ReservationTime> reservedTimes)
        {
            var availableTimes = new List<DateTime>();
            var currentDateTime = date.Date.Add(restaurant.OpeningTime);

            while (currentDateTime + TimeSpan.FromHours(2) <= date.Date.Add(restaurant.ClosingTime)) // Da eine Reservation ungefähr 2 stunden geht kann man nicht 2 stundne vor den Schliess Zeiten Reservieren.
            {
                if (IsTimeSlotAvailable(restaurant, currentDateTime, numPeople, reservedTimes))
                {
                    availableTimes.Add(currentDateTime);
                }
                currentDateTime = currentDateTime.AddMinutes(30); // Check every 30 minutes
            }

            return availableTimes;
        }

        private bool IsTimeSlotAvailable(Restaurant restaurant, DateTime startTime, int numPeople, HashSet<ReservationTime> reservedTimes)
        {
            DateTime endTime = startTime.AddHours(2); 

            int totalSeats = restaurant.TableCapacities.Sum(tc => tc.Key * tc.Value);

            int reservedSeatsDuringSlot = reservedTimes
                .Where(rt => rt.Start < endTime && rt.Start.AddHours(2) > startTime) // Findet Überschneidungen
                .Sum(rt => rt.NumPeople);

            // Prüfen, ob genügend Sitzplätze für die neue Reservierung verfügbar sind
            return totalSeats - reservedSeatsDuringSlot >= numPeople;
        }

        public async Task<string> MakeReservationAsync(Restaurant restaurant, User user, DateTime startTime, int numPeople)
        {
            if (restaurant == null) return "Restaurant not found";

            var endTime = startTime.AddHours(2);
            if (IsTimeSlotAvailable(restaurant, startTime, numPeople, new HashSet<ReservationTime>())) // Use an empty hashset as a placeholder
            {
                Reservation newReservation = new Reservation(user, restaurant, startTime, endTime, numPeople);
                // Add the reservation in a way that reflects the change in available seats
                await _databaseHelper.SaveReservation(newReservation);
                return $"Reservation made for {numPeople} people at {startTime}";
            }

            return "No available table for the selected time";
        }

        private class ReservationTime
        {
            public DateTime Start { get; set; }
            public int NumPeople { get; set; }
        }
    }
}
