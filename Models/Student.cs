using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_8.Models
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }

        public List<Course> RegisteredCourses { get; }

        public Student(string name)
        {
            Id = GenerateRandomId();
            Name = name;
            RegisteredCourses = new List<Course>();
        }

        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            RegisteredCourses.AddRange(selectedCourses);
        }

        public int TotalWeeklyHours()
        {
            return RegisteredCourses.Sum(c => c.WeeklyHours);
        }

        private int GenerateRandomId()
        {
            // generate a random 6-digit number as the ID
            Random rnd = new Random();
            return rnd.Next(100000, 999999);
        }
    }
}