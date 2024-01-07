using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Modules
{
	public class Person
	{
		public int Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public bool Available { get; set; }

		public Person() { }

		public Person(string firstname, string lastname, bool available)
		{
			Firstname = firstname;
			Lastname = lastname;
			Available = available;
		}
	}

}
