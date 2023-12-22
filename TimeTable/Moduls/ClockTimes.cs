namespace TimeTable.Moduls
{
    public class ClockTimes
    {
        //Diese Klasse muss nochmals überarbeitet werden sobalt wir 
        //mehr gedankten über den Algorythmus und der eingabe der Daten 
        //gemacht haben.

        string Bezeichnung { get; set; }
        private int Hour;
        private int Minutes;

        public ClockTimes(int Hour, int Minutes, string bezeichnung)
        {
            SetHour(Hour);
            SetMinutes(Minutes);
            Bezeichnung = bezeichnung;
        }
        public void SetHour(int Hour)
        {
            this.Hour = Hour;
        }
        public int GetHour()
        {
            return Hour;
        }
        public void SetMinutes(int Minutes)
        {
            this.Minutes = Minutes;
        }
        public int GetMinutes()
        {
            return Minutes;
        }

    }
}
