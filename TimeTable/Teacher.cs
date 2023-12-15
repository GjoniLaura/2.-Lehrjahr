using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable
{
    public class Teacher : Person
    {
        private string _teachedSubject;
        private bool _teached;
        private int _numberOfWorkDays;
        public Teacher(string fn, string ln, bool av, string teachedSubject, bool teached, int numberOfWorkDays) : base(fn, ln, av)
        {
            setTeachedSubject(teachedSubject);
            setTeached(teached);
            setNumberOfWorkDays(numberOfWorkDays);
        }
        public string getTeachedSubject()
        {
            return _teachedSubject;
        }

        public void setTeachedSubject(string teachedSubject)
        {
            _teachedSubject = teachedSubject;
        }

        public bool getTeached()
        {
            return _teached;
        }

        public void setTeached(bool teached)
        {
            _teached = teached;
        }

        public int getNumberOfWorkDays()
        {
            return _numberOfWorkDays;
        }

        public void setNumberOfWorkDays(int numberOfWorkDays)
        {
            _numberOfWorkDays = numberOfWorkDays;
        }
    }


}