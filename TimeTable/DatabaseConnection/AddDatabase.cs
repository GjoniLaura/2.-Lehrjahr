using System;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using TimeTable.DatabaseConnection;


namespace TimeTable.DatabaseConnection
{
	public class AddDatabase
	{
	}

	public class TeacherDatabaseConnection
	{
		public static void setTeacher(string _firstname, string _lastname, bool _available, List<Subject> teachedSubject, bool teached, int numberOfWorkDays)
		{
			using (var dbContext = new TimeTableContext())
			{
				Teacher Teacher = new Teacher(_firstname, _lastname, _available, teachedSubject, teached, numberOfWorkDays);

				dbContext.person.Add(Teacher);
				dbContext.SaveChanges();
			}
		}

		public static List<Teacher> getTeacher()
		{
			using (var dbContext = new TimeTableContext())
			{
				List<Teacher> teachers = dbContext.person.OfType<Teacher>().Include(t => t.TeachedSubject).ToList();
				return teachers;
			}
		}
     }

	public class AddStudent
	{

	}
}
