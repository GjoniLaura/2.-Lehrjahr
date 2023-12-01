using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTime
{
    public abstract class Person
    {
        private string _firstname;
        private string _lastname;
        private bool _available;

        public Person(string fn, string ln, bool av)
        {
            setFirstname(fn);
            setLastname(ln);
            setAvailability(av);
        }

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
        }
    }
}