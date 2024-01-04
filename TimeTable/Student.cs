using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using TimeTable;

namespace TimeTable
{

	public class Student : Person
	{
		public int Id { get; set; }
		public Education Education { get; set; }
		public List<Teacher> Teachers { get; set; }
		public int NumberOfLessons { get; set; }
		public int EducationSemester { get; set; }

		public string Class { get; set; }

		public Student() { }

		public Student(string firstname, string lastname, bool available, Education education, List<Teacher> teacher, int numberoflesson, int educationsemester, string classe) : base(firstname, lastname, available)
		{
			Education = education;
			Teachers = teacher;
			NumberOfLessons = numberoflesson;
			EducationSemester = educationsemester;
			Class = classe;
		}


	}

}



