using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Moduls
{
    public abstract class Person
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        bool Available { get; set; }

        public Person(string firstname, string lastname, bool available)
        {
            Firstname = firstname;
            Lastname = lastname;
            Available = available;
        }
    }
}
