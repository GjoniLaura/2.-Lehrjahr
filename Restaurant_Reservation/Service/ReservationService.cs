using Restaurant_Reservation.Klassen;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
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
                .Select(r => r.Start)
                .ToHashSet();

            return GetAvailableTimesForRestaurant(restaurant, date, numPeople, reservedTimes);
        }

        private List<DateTime> GetAvailableTimesForRestaurant(Restaurant restaurant, DateTime date, int numPeople, HashSet<DateTime> reservedTimes)
        {
            var availableTimes = new List<DateTime>();
            var currentDateTime = date.Date.Add(restaurant.OpeningTime);

            while (currentDateTime + TimeSpan.FromHours(2) <= date.Date.Add(restaurant.ClosingTime))
            {
                bool available = restaurant.Tables.Any(table => IsTableAvailable(table, currentDateTime, currentDateTime.AddHours(2), numPeople, reservedTimes));
                if (available)
                {
                    availableTimes.Add(currentDateTime);
                }

                currentDateTime = currentDateTime.AddMinutes(30); // Check every 30 minutes
            }

            return availableTimes;
        }

        private bool IsTableAvailable(Table table, DateTime startTime, DateTime endTime, int numPeople, HashSet<DateTime> reservedTimes)
        {
            if (table.Seats < numPeople) return false;
            if (reservedTimes.Contains(startTime)) return false;

            foreach (var reservation in table.Reservations)
            {
                if (!(endTime <= reservation.Start || startTime >= reservation.End))
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<string> MakeReservationAsync(Restaurant selRestaurant, User selUser, DateTime startTime, int numPeople)
        {
            var restaurant = selRestaurant;
            if (restaurant == null) return "Restaurant not found";

            var endTime = startTime.AddHours(2);
            foreach (var table in restaurant.Tables)
            {
                if (IsTableAvailable(table, startTime, endTime, numPeople, new HashSet<DateTime>())) // Empty hash set as placeholder
                {
                    Reservation newReservation = new Reservation(selUser, restaurant, startTime, endTime, numPeople);
                    table.Reservations.Add(newReservation);
                    await _databaseHelper.SaveReservation(newReservation);
                    return $"Reservation made for {numPeople} people at {startTime}";
                }
            }

            return "No available table for the selected time";
        }
    }
}
