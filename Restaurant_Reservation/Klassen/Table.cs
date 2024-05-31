namespace Restaurant_Reservation.Klassen
{
    public class Table
    {
        public int TableId { get; set; }
        public int Seats { get; set; }
        public Restaurant restaurant { get; set; }  
        public List<Reservation> Reservations { get; set;} = new List<Reservation>();
    }
}
