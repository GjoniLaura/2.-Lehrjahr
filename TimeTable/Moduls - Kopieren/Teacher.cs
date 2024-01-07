using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Moduls
{
    public class Teacher : Person
    {
		public List<Subject> TeachedSubject { get; set; }
		public bool Teached { get; set; }
		 public	int NumberOfWorkDays { get; set; }
		public Teacher(string firstname, string lastname, bool available, List<Subject> teachedSubject, bool teached, int numberOfWorkDays) : base(firstname, lastname, available)
		{
			TeachedSubject = teachedSubject;
			Teached = teached;
			NumberOfWorkDays = numberOfWorkDays;
		}

	}


}