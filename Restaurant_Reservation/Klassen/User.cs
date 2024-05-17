namespace Restaurant_Reservation.Klassen
{
    public class User
    {
        public string Vornamen { get; set; }
        public string Nachnamen { get; set; }
        public int AnzPersonen { get; set; }
        public string Telefonummer { get; set; }
        public string Bemerkung { get; set; }

        public User(string vornamename, string nachnamen, int anz, string tele, string bem)
        {
            Vornamen = vornamename;
            Nachnamen = nachnamen;
            AnzPersonen = anz;
            Telefonummer = tele;
            Bemerkung = bem;
        }

        public User() { }
    }

}