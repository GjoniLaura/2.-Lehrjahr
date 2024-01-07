using System;
using System.ComponentModel.DataAnnotations;


namespace TimeTable.Modules
{

	public class Student : Person
	{
		public Education Education { get; set; }
		public List<Teacher> Teachers { get; set; }
		public int NumberOfLessons { get; set; }
		public int EducationSemester { get; set; }
		public Person Person { get; set; }

		public string Class { get; set; }

		public Student() { }

		public Student(string firstname, string lastname, bool available, Education education, List<Teacher> teacher, int numberoflesson, int educationsemester, string classe) : base(firstname, lastname, available)
		{
			Education = education;
			Teachers = teacher ?? new List<Teacher>();
			NumberOfLessons = numberoflesson;
			EducationSemester = educationsemester;
			Class = classe;
		}


	}

}



