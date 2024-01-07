using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Moduls;

namespace TimeTable.Modules
{
	public class Teacher : Person
	{
		public List<Subject> TeachedSubject { get; set; }
		public bool Teached { get; set; }
		public int NumberOfWorkDays { get; set; }
		public Person Person { get; set; }

		public List<ClockTimes> UnavailableTimeSlots { get; set; }

		public Teacher() { }

		public Teacher(string firstname, string lastname, bool available, List<Subject> teachedSubject, bool teached, int numberOfWorkDays, List<ClockTimes> unavailabel) : base(firstname, lastname, available)
		{
			TeachedSubject = teachedSubject ?? new List<Subject>();
			Teached = teached;
			NumberOfWorkDays = numberOfWorkDays;

			UnavailableTimeSlots = unavailabel ?? new List<ClockTimes>();
		}


	}


}