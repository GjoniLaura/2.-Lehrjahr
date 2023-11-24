﻿using System;

namespace TimeTable
{
  
    public class Student : Person
    {
      private string _Education;
      private string _Teacher;
      private int _Id;
      private int _NumberOfLessons;
      private int _EducationSemester;
      private string _Modules;
      private string _Subject;
      private string _Class;

      public Student(string fn, string ln, bool av, string education, string teacher, int id, int numberoflesson, int educationsemester, string modules, string subjet, string Class) : base(fn, ln, av)
      {
        setEducation(education);
        setTeacher(teacher);
        setId(id);
        setNumberOfLessons(numberoflesson);
        setEducationSemester(educationsemester);
        setModules(modules);
        setSubjects(subjet);
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
      public void setId(int value)
      {
        _Id = value;
      }
      public int getId()
      {
        return _Id;
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
      public void setModules(string value)
      {
        _Modules = value;
      }
      public string getModules()
      {
        return _Modules;
      }
      public void setSubjects(string value)
      {
        _Subject = value;
      }
      public string getSubjects()
      {
        return _Subject;
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



