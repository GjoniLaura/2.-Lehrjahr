using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Moduls
{
    public class Student : Person
    {
		public Education Education { get; set; }
        public List<Teacher> Teachers { get; set; }
        public int StudentId { get; set; }
		public int NumberOfLessons { get; set; }
		public int EducationSemester { get; set; }

        public string Class { get; set; }

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



