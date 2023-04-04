using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_8.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }

        public FulltimeStudent(string name) : base(name)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalHours = selectedCourses.Sum(c => c.WeeklyHours);
            if (totalHours > MaxWeeklyHours)
            {
                throw new Exception($"Total weekly hours of registered courses cannot exceed {MaxWeeklyHours}");
            }

            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $"{Id} - {Name} (Full time)";
        }
    }
}