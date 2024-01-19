namespace TimeTable.Modules
{
    public class ClockTimes
    {

        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public ICollection<Teacher> teachers { get; set; }

        public ClockTimes() { }

        public ClockTimes(TimeSpan starTime, TimeSpan endTime, DayOfWeek dayofweek, string bezeichnung)
        {
            StartTime = starTime;
            EndTime = endTime;
            DayOfWeek = dayofweek;
            Bezeichnung = bezeichnung;
        }
    }

    public class Lesson
    {
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public ClockTimes TimeSlot { get; set; }

        public Lesson(Teacher teacher, Subject subject, ClockTimes timeSlot, Student student)
        {
            Teacher = teacher;
            Student = student;
            Subject = subject;
            TimeSlot = timeSlot;
        }

        public Lesson(Teacher teacher, Student student, Subject subject, ClockTimes timeSlot)
        {
            Teacher = teacher;
            Student = student;
            Subject = subject;
            TimeSlot = timeSlot;
        }
    }
}
