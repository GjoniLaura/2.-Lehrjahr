namespace TimeTable.Modules
{
    public class ClockTimes
    {

        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public ClockTimes() { }

        public ClockTimes(TimeSpan starTime, TimeSpan endTime, DayOfWeek dayofweek, string bezeichnung)
        {
            StartTime = starTime;
            EndTime = endTime;
            DayOfWeek = dayofweek;
            Bezeichnung = bezeichnung;
        }
    }

}
