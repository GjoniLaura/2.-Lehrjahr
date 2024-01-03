using System;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using TimeTable.DatabaseConnection;


namespace TimeTable.DatabaseConnection
{
	public class AddDatabase
	{
	}

	public class AddTeacher
	{
		public static void setteacher(string _firstname, string _lastname, bool _available, string teachedSubject, bool teached, int numberOfWorkDays)
		{
			using (var dbContext = new TimeTableContext())
			{
				Teacher Teacher = new Teacher(_firstname, _lastname, _available, teachedSubject, teached, numberOfWorkDays);

				dbContext.teacher.Add(Teacher);
				dbContext.SaveChanges();
			}

		}
     }

	public class AddStudent
	{

	}
}
