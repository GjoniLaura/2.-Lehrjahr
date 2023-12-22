using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Moduls
{
    public class Student : Person
    {
        Education Education { get; set; }
        Teacher Teacher { get; set; }
        int StudentId { get; set; }
        int NumberOfLessons { get; set; }
        int EducationSemester { get; set; }
        private List<Subject> Subjects = new List<Subject>();
        //Man muss auf die n zu n beziehung zwischen student und modules/subjects achten
        string Class { get; set; }

        public Student(string firstname, string lastname, bool available, Education education, Teacher teacher, int id, int numberoflesson, int educationsemester, string modules, string subjet, string klass) : base(firstname, lastname, available)
        {
            Education = education;
            Teacher = teacher;
            NumberOfLessons = numberoflesson;
            EducationSemester = educationsemester;
            Class = Class;
        }


    }
}



