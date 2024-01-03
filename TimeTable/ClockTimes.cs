namespace TimeTable
{
    public class ClockTimes
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
		public int Hour { get; set; }
		public int Minutes { get; set; }

		public ClockTimes()
		{
		}

		public ClockTimes(int hour, int minutes, string bezeichnung)
        {
            Hour = hour;
            Minutes = minutes;
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
