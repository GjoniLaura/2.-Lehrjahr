using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable
{
    public abstract class Person
    {
        public string _firstname { get; set; }
		public string _lastname { get; set; }
		public bool _available { get; set; }

        public Person() { }
        public Person(string fn, string ln, bool av)
        {
            _firstname = fn;
            _lastname = ln;
            _available = av;
        }
/*
        public string getFirstname()
        {
            return _firstname;
        }
        public void setFirstname(string fn)
        {
            _firstname = fn;
        }
        public string getLastname()
        {
            return _lastname;
        }
        public void setLastname(string ln)
        {
            _lastname = ln;
        }
        public bool getAvailability()
        {
            return _available;
        }

        public void setAvailability(bool av)
        {
            _available = av;
        }*/
    }
}