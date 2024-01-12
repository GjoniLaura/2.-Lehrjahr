namespace TimeTable.Modules
{
    public class Room
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public int NumberOfSeats { get; set; }

        public Room() { }
        public Room(string designation, int numberOfSeats)
        {
            Designation = designation;
            NumberOfSeats = numberOfSeats;
        }
    }
}
