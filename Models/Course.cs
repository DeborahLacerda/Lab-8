using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_8.Models
{
    public class Course
    {
        public string Code { get; }
        public string Title { get; }
        public string Label
        {
            get
            {
                return Title + " - " + WeeklyHours + " hours/Week";
            }
        }
        public int WeeklyHours { get; set; }

        public Course(string code, string title)
        {
            Code = code;
            Title = title;
        }
    }
}