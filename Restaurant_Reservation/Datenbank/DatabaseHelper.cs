using Firebase.Database;
using System.IO;
using Firebase.Database;
using Firebase.Database.Query;
using Restaurant_Reservation.Klassen;


namespace Restaurant_Reservation.Datenbank
{
    public class DatabaseHelper
    {
        private readonly FirebaseClient _firebase;

        public DatabaseHelper()
        {
            _firebase = new FirebaseClient("https://restaurant-reservation-6e780-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public static async Task PostUserInfo(User user)
        {
            var databaseHelper = new DatabaseHelper();

            var result = await databaseHelper._firebase
                .Child("UserInfos")
                .PostAsync(user);
        }

        public static async Task PostRestaurant(Restaurant restaurant)
        {
            var databaseHelper = new DatabaseHelper();
            var restul = await databaseHelper._firebase
                .Child("Restaurant")
                .PostAsync(restaurant);
        }

        public static async Task<List<Restaurant>> GetAllRestaurants()
        {
            var databaseHelper = new DatabaseHelper();
            var restaurants = await databaseHelper._firebase
                .Child("Restaurant")
                .OnceAsync<Restaurant>();

            return restaurants.Select(r => r.Object).ToList();
        }

        public async Task<List<Reservation>> GetReservationsForRestaurant(int restaurantId)
        {
            var reservations = await _firebase
                .Child("reservations")
                .OnceAsync<Reservation>();

            return reservations
                .Select(item => item.Object)
                .Where(reservation => reservation.restaurant.Id == restaurantId)
                .ToList();
        }

        public async Task SaveReservation(Reservation reservation)
        {
            await _firebase
                .Child("reservations")
                .PostAsync(reservation);
        }


    }
}
