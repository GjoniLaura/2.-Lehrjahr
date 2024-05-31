using Restaurant_Reservation.Klassen;

namespace Restaurant_Reservation.Service
{
    public class ReservationService
    {
        private List<Restaurant> _restaurants;

        public List<DateTime> GetAvailableTimes(Restaurant Restaurantselect, DateTime date, int numPeople)
        {
            var restaurant = Restaurantselect;
            if (restaurant == null) return new List<DateTime>();

            return GetAvailableTimesForRestaurant(restaurant, date, numPeople);
        }

        private List<DateTime> GetAvailableTimesForRestaurant(Restaurant restaurant, DateTime date, int numPeople)
        {
            var availableTimes = new List<DateTime>();
            var currentDateTime = date.Date.Add(restaurant.OpeningTime);

            while (currentDateTime + TimeSpan.FromHours(2) <= date.Date.Add(restaurant.ClosingTime))
            {
                bool available = restaurant.Tables.Any(table => IsTableAvailable(table, currentDateTime, currentDateTime.AddHours(2), numPeople));
                if (available)
                {
                    availableTimes.Add(currentDateTime);
                }

                currentDateTime = currentDateTime.AddMinutes(30); // Check every 30 minutes
            }

            return availableTimes;
        }

        private bool IsTableAvailable(Table table, DateTime startTime, DateTime endTime, int numPeople)
        {
            if (table.Seats < numPeople) return false;

            foreach (var reservation in table.Reservations)
            {
                if (!(endTime <= reservation.Start || startTime >= reservation.End))
                {
                    return false;
                }
            }

            return true;
        }
        public string MakeReservation(Restaurant selRestaurant, User selUser, DateTime startTime, int numPeople)
        {
            var restaurant = selRestaurant;
            if (restaurant == null) return "Restaurant not found";

            var endTime = startTime.AddHours(2);
            foreach (var table in restaurant.Tables)
            {
                if (IsTableAvailable(table, startTime, endTime, numPeople))
                {
                    Reservation newReservation = new Reservation(selUser, restaurant, startTime, endTime, numPeople);
                    table.Reservations.Add(newReservation);
                    return $"Reservation made for {numPeople} people at {startTime}"; 
                }
            }

            return "No available table for the selected time";
        }
    }
}
