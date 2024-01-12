using System;
using System.Collections.Generic;
using System.Linq;
using TimeTable.Modules;


namespace TimeTable.Algorithmus
{
    public class TimeTableGenerator
    {
        public List<Lesson> GenerateTimeTable(List<Teacher> teachers, List<Student> students, List<Subject> subjects, List<ClockTimes> timeSlots)
        {
            List<Lesson> timeTable = new List<Lesson>();
            GenerateSchedule(teachers, students, subjects, timeSlots, 0, timeTable);
            return timeTable;
        }

        private bool IsTeacherAvailable(Teacher teacher, ClockTimes timeSlot, List<Lesson> currentSchedule)
        {
            return !currentSchedule.Any(lesson => lesson.Teacher == teacher && lesson.TimeSlot == timeSlot);
        }

        private bool IsStudentAvailable(Student student, ClockTimes timeSlot, List<Lesson> currentSchedule)
        {
            return !currentSchedule.Any(lesson => lesson.Student == student && lesson.TimeSlot == timeSlot);
        }

        private void GenerateSchedule(List<Teacher> teachers, List<Student> students, List<Subject> subjects, List<ClockTimes> timeSlots, int currentSlot, List<Lesson> timeTable)
        {
            if (currentSlot >= timeSlots.Count)
            {
                return;
            }

            foreach (var teacher in teachers)
            {
                foreach (var student in students)
                {
                    foreach (var subject in subjects)
                    {
                        foreach (var timeSlot in timeSlots)
                        {
                            if (IsTeacherAvailable(teacher, timeSlot, timeTable) && IsStudentAvailable(student, timeSlot, timeTable))
                            {
                                Lesson lesson = new Lesson(teacher, student, subject, timeSlot);
                                timeTable.Add(lesson);

                                GenerateSchedule(teachers, students, subjects, timeSlots, currentSlot + 1, timeTable);

                                if (timeTable.Count == timeSlots.Count * teachers.Count * students.Count)
                                {
                                    return;
                                }

                                timeTable.RemoveAt(timeTable.Count - 1);
                            }
                        }
                    }
                }
            }
        }
    }
}


