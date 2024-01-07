using System.ComponentModel.DataAnnotations;


namespace TimeTable.Modules
{
	public class Education
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Subject> Subjects { get; set; }
		public int AnzLessons { get; set; }


		public Education() { }
		public Education(string name, List<Subject> subjects, int anzLessons)
		{
			Name = name;
			Subjects = subjects ?? new List<Subject>();
			AnzLessons = anzLessons;
		}

	}
}
