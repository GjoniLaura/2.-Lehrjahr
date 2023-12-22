using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Moduls
{
    public class Teacher : Person
    {
        string TeachedSubject { get; set; }
        bool Teached { get; set; }
        int NumberOfWorkDays { get; set; }
        public Teacher(string firstname, string lastname, bool available, string teachedSubject, bool teached, int numberOfWorkDays) : base(firstname, lastname, available)
        {
            TeachedSubject = teachedSubject;
            Teached = teached;
            NumberOfWorkDays = numberOfWorkDays;
        }

    }


}