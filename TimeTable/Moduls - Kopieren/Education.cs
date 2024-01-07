namespace TimeTable.Moduls
{
    public class Education
    {
		public string Id { get; set; }
		public string Name { get; set; }
		public List<Subject> Subjects { get; set; }
		public int AnzLessons { get; set; }

		public Education(string name, List<Subject> subjects, int anzLessons)
		{
			Name = name;
			Subjects = subjects;
			AnzLessons = anzLessons;
		}
	}
}
