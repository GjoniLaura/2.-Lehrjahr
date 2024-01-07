namespace TimeTable.Moduls
{
    public class Subject
    {
		public int Id { get; set; }
		public string _designation { get; set; }
		public string _description { get; set; }
		public string _premises { get; set; }

		public Subject() { }

		public Subject(string designation, string description, string premises)
		{
			_designation = designation;
			_description = description;
			_premises = premises;
		}

	}
}