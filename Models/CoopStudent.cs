using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_8.Models
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }

        public CoopStudent(string name) : base(name)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalHours = selectedCourses.Sum(c => c.WeeklyHours);
            if (totalHours > MaxWeeklyHours)
            {
                throw new Exception($"Total weekly hours of registered courses cannot exceed {MaxWeeklyHours}");
                
            }

            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception($"Cannot register more than {MaxNumOfCourses} courses");
            }

            base.RegisterCourses(selectedCourses);
            
        }

        public override string ToString()
        {
            return $"{Id} - {Name} (Coop)";
        }
    }
}