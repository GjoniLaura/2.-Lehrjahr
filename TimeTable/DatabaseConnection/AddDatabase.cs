using System;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using TimeTable.DatabaseConnection;
using TimeTable.Modules;

namespace TimeTable.DatabaseConnection
{
    public class AddDatabase
	{
	}

	public class TeacherDatabaseConnection
	{
		public static void setTeacher(string _firstname, string _lastname, bool _available, List<Subject> teachedSubject, bool teached, int numberOfWorkDays, List<ClockTimes> unavailabel)
		{

			using (var dbContext = new TimeTableContext())
			{
                foreach (Subject subject in teachedSubject)
                {
                        dbContext.Attach(subject);
                }

                if (unavailabel!= null)
				{
					foreach(ClockTimes time in unavailabel)
					{
						dbContext.Attach(time);
					}
				}

				Teacher Teacher = new Teacher(_firstname, _lastname, _available, teachedSubject, teached, numberOfWorkDays, unavailabel);

				dbContext.teacher.Add(Teacher);
				dbContext.SaveChanges();
			}
		}

		public static async Task<List<Teacher>> getTeacher()
		{
			using (var dbContext = new TimeTableContext())
			{
				List<Teacher> teachers = await dbContext.teacher.Include("TeachedSubject").Include("UnavailableTimeSlots").ToListAsync();
				return teachers;
			}
		}
     }

	public class StudentDatabaseConnection
	{
        public static void setStudent(string firstname, string lastname, bool available, Education education, List<Teacher> teacher, int numberoflesson, int educationsemester, string classe)
        {
            using (var dbContext = new TimeTableContext())
            {
                var educationSubjects = new List<Subject>(education.Subjects);
                education.Subjects.Clear();

                foreach (var subject in educationSubjects)
                {
                    if (!dbContext.subject.Any(s => s.Id == subject.Id))
                    {
                        dbContext.subject.Add(subject);
                    }
                }

                foreach (Teacher t in teacher)
                {
                    var teacherSubjects = new List<Subject>(t.TeachedSubject);
                    t.TeachedSubject.Clear();

                    foreach (var subject in teacherSubjects)
                    {
                        if (!dbContext.subject.Any(s => s.Id == subject.Id))
                        {
                            dbContext.subject.Add(subject);
                        }
                    }
                }
                dbContext.Attach(education);
                foreach (Teacher t in teacher)
                {
                    dbContext.Attach(t);
                }

                Student student = new Student(firstname, lastname, available, education, teacher, numberoflesson, educationsemester, classe);
                dbContext.student.Add(student);
                dbContext.SaveChanges();
            }
        }


public static async Task<List<Student>> getStudent()
{
    using (var dbContext = new TimeTableContext())
    {
        List<Student> students = await dbContext.student
            .Include("Teachers")
            .Include(s => s.Education)
                .ThenInclude(e => e.Subjects)
            .ToListAsync();
        return students;
    }
}
	}

	public class SubjectDatabaseConnection
	{
		public static void setSubject(string designation, string description, string premises)
		{
			using (var dbContext = new TimeTableContext())
			{
				Subject subject = new Subject(designation, description, premises);
				dbContext.subject.Add(subject);
				dbContext.SaveChanges();
			}
		}

		public static List<Subject> getSubject()
		{
			using(var dbContext = new TimeTableContext())
			{
				List<Subject> subject = dbContext.subject.ToList();
				return subject;
			}
		}
	}

	public class EducationDatabaseConnection
	{
		public static void setEducation(string name, List<Subject> subjects, int anzLessons)
		{
			using (var dbContext = new TimeTableContext())
			{
				foreach (Subject S in subjects)
				{
                        dbContext.Attach(S);
                }

                Education education= new Education(name,subjects,anzLessons);
				dbContext.education.Add(education);
				dbContext.SaveChanges();
			}
		}

		public static async Task<List<Education>> getEducation()
		{
			using (var dbContext = new TimeTableContext())
			{
                List<Education> educations = await dbContext.education.Include("Subjects").ToListAsync();
				return educations;
			}
		}
	}

	public class ClockTimeDatabaseConnection
	{
		public static void setClockTime(TimeSpan starTime, TimeSpan endTime, DayOfWeek dayofweek, string bezeichnung)
		{
			using (var dbContext = new TimeTableContext())
			{

				ClockTimes clocktime = new ClockTimes(starTime, endTime,dayofweek,bezeichnung);
				dbContext.time.Add(clocktime);
				dbContext.SaveChanges();
			}
		}

		public static List<ClockTimes> getClockTimes()
		{
			using (var dbContext = new TimeTableContext())
			{
				List<ClockTimes> clocktime = dbContext.time.ToList();
				return clocktime;
			}
		}
	}

	public class RoomDatabaseConnection
	{
		public static void setRoom(string designation, int numberOfSeats)
		{
			using(var dbContext = new TimeTableContext())
			{
				Room room = new Room(designation, numberOfSeats);
				dbContext.room.Add(room);
				dbContext.SaveChanges();
			}
		}

		public static List<Room> getRoom()
		{
			using(var dbContext = new TimeTableContext())
			{
				List<Room> rooms = dbContext.room.ToList();
				return rooms;
			}
		}
	}
}