namespace TimeTable.Moduls
{
    public class ClockTimes
    {
		//Diese Klasse muss nochmals überarbeitet werden sobalt wir 
		//mehr gedankten über den Algorythmus und der eingabe der Daten 
		//gemacht haben.

		public string Bezeichnung { get; set; }
        public int Hour { get; set; }
		public int Minutes { get; set; }

        public ClockTimes(int hour, int minutes, string bezeichnung)
        {
            Hour = hour;
            Minutes= minutes;
            Bezeichnung = bezeichnung;
        }

    }
}
