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

				dbContext.teacher.Add(Teacher);
				dbContext.SaveChanges();
			}
		}

		public static List<Teacher> getTeacher()
		{
			using (var dbContext = new TimeTableContext())
			{
				List<Teacher> teachers = dbContext.teacher.Include(t => t.TeachedSubject).ToList();
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
				foreach(Teacher t in teacher)
				{
					dbContext.Attach(t);
				}

				Student student = new Student(firstname, lastname, available, education, teacher, numberoflesson, educationsemester, classe);

				dbContext.student.Add(student);
				dbContext.SaveChanges();
			}


		}

		public static List<Student> getStudent()
		{
			using (var dbContext = new TimeTableContext())
			{
				List<Student> students = dbContext.student.Include(t => t.Teachers).ToList();
				return students;
			}
		}
	}
}
