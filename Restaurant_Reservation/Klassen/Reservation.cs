namespace Restaurant_Reservation.Klassen
{
    public class Reservation
    {
        public User User { get; set; }
        public Restaurant restaurant { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Reservation(User user, Restaurant res, DateTime start, DateTime end)
        {
            User = user;
            this.restaurant = res;
            Start = start;
            End = end;
        }
    }
}
