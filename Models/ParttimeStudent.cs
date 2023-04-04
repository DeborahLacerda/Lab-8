using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_8.Models
{
    public class ParttimeStudent : Student
    {
        public static int MaxNumOfCourses { get; set; }

        public ParttimeStudent(string name) : base(name)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception($"Cannot register more than {MaxNumOfCourses} courses");
            }

            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $"{Id} - {Name} (Part time)";
        }
    }
}