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
            var DatenbankHelper = new DatabaseHelper();

            var result = await DatenbankHelper._firebase
                .Child("UserInfos")
                .PostAsync(user);
        }

    }
}
