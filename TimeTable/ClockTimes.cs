namespace TimeTable
{
	public class ClockTimes
	{

		public int Id { get; set; }
		public string Bezeichnung { get; set; }
		public int Hour { get; set; }
		public int Minutes { get; set; }

		public ClockTimes(int hour, int minutes, string bezeichnung)
		{
			Hour = hour;
			Minutes = minutes;
			Bezeichnung = bezeichnung;
		}

	}

}
