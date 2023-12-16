using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using TimeTable;

namespace TimeTable
{
  
    public class Student : Person
    {
      public int Id { get; set; }

      private string _Education;
      private string _Teacher;       
      private int _NumberOfLessons;
      private int _EducationSemester;
      List<Subject> Subjects { get; set; }
      //Man muss auf die n zu n beziehung zwischen student und modules/subjects achten
      private string _Class;

     public Student() { }

      public Student(string fn, string ln, bool av, string education, string teacher, int id, int numberoflesson, int educationsemester, string modules, string subjet, string Class) : base(fn, ln, av)
      {
        setEducation(education);
        setTeacher(teacher);
        Id = id;
        setNumberOfLessons(numberoflesson);
        setEducationSemester(educationsemester);
        setClass(Class);
      }

      public void setEducation(string value)
      {
        _Education = value;
      }
      public string getEducation()
      {
        return _Education;
      }
      public void setTeacher(string value)
      {
        _Teacher = value;
      }
      public string getTeacher()
      {
        return _Teacher;
      }
      public void setNumberOfLessons(int value)
      {
        _NumberOfLessons = value;
      }
      public int getNumberOfLessons()
      {
        return _NumberOfLessons;
      }
      public void setEducationSemester(int value)
      {
        _EducationSemester = value;
      }
      public int getEducationSemester()
      {
        return _EducationSemester;
      }
      public void setClass(string value)
      {
        _Class = value;
      }
      public string getClass()
      {
        return _Class;
      }
    }
 }



