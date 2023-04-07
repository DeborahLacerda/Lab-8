using Lab_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        public List<Student> Students
        {
            get
            {
                return (List<Student>)Session["students"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateStudentDropdown();

                // Load available type courses radio and courses into checkbox list 
                LoadAvailableCourses();
                title1.Text = "Following Course are currently availible for registration";
                title1.Visible = true;
                StudentCoursesInfo.Visible = false;


                string selectedStudentId = Request.QueryString["studentId"];
                if (!string.IsNullOrWhiteSpace(selectedStudentId))
                {
                    StudentDropdown.SelectedValue = selectedStudentId;
                    Student selectedStudent = Students.FirstOrDefault(s => s.Id.ToString() == selectedStudentId);
                    if (selectedStudent != null)
                    {
                        LoadSelectedCourses(selectedStudent);
                    }

                }

            }

        }


        protected void SubmitButton_Click(object sender, EventArgs e)
        {

            // Check if student is provided
            string selectedStudentId = StudentDropdown.SelectedValue;
            if (string.IsNullOrWhiteSpace(selectedStudentId))

            {
                ShowErrorMessage("You must select a student!");
                return;
            }
            // Check if type course is provided

            // Check if course is provided
            string courses = CoursesCheckBoxList.SelectedValue;
            if (string.IsNullOrWhiteSpace(courses))
            {
                ShowErrorMessage("You must select a one course!");
                return;
            }


            // Validate registration rules based on course type

            var selectedCourses = new List<Course>();
            Student selectedStudent = Students.FirstOrDefault(s => s.Id.ToString() == selectedStudentId);


            foreach (ListItem item in CoursesCheckBoxList.Items)
            {
                if (item.Selected)
                {
                    selectedCourses.Add(Helper.GetCourseByCode(item.Value));
                }
            }

            try
            {
                selectedStudent.RegisterCourses(selectedCourses);
                ShowSelectedCourses(selectedCourses);
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex.Message);
            }
        }
        private void ShowStudentCoursesInfo(Student student)
        {
            if (student.RegisteredCourses.Count > 0)
            {
                int totalHours = student.RegisteredCourses.Sum(c => c.WeeklyHours);
                StudentCoursesInfo.Text = $"Student has enrolled in {student.RegisteredCourses.Count} courses with a total of {totalHours} weekly hours.";
                StudentCoursesInfo.Visible = true;
            }
            else
            {
                StudentCoursesInfo.Visible = false;
            }
        }
        private void ShowSelectedCourses(List<Course> selectedCourses)
        {
            //Clean
            ErrorLabel.Text = "";
            ErrorLabel.Visible = false;
            title1.Visible = true;
            StudentCoursesInfo.Visible = false;

            // Calculate total hours
            int totalSelectedHours = selectedCourses.Sum(c => c.WeeklyHours);
            string selectedStudentId = StudentDropdown.SelectedValue;
            Student selectedStudent = Students.FirstOrDefault(s => s.Id.ToString() == selectedStudentId);
            if (selectedStudent != null)
            {
                ShowStudentCoursesInfo(selectedStudent);
            }
        }

        private void LoadAvailableCourses()
        {
            List<Course> courses = Helper.GetAvailableCourses();
            CoursesCheckBoxList.DataSource = courses;

            //create metod ou course can be just "Label" or nameof(Course.Label)
            CoursesCheckBoxList.DataTextField = "Label";
            CoursesCheckBoxList.DataValueField = "Code";
            CoursesCheckBoxList.DataBind();
        }

        protected void LoadSelectedCourses(Student student)
        {
            if (student.RegisteredCourses.Count == 0)
            {
                CoursesCheckBoxList.ClearSelection();
                title1.Visible = true;
                StudentCoursesInfo.Visible = false;
            }
            else
            {
                foreach (ListItem item in CoursesCheckBoxList.Items)
                {
                    item.Selected = student.RegisteredCourses.Any(c => c.Code == item.Value);
                }
                title1.Visible = true;
            }
            ShowStudentCoursesInfo(student);
        }

        protected void StudentDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStudentId = StudentDropdown.SelectedValue;
            if (string.IsNullOrWhiteSpace(selectedStudentId))
            {
                ShowErrorMessage("You must select a student!");
                CoursesCheckBoxList.ClearSelection();
                title1.Visible = true;
                StudentCoursesInfo.Visible = false;
                return;
            }

            Student selectedStudent = Students.FirstOrDefault(s => s.Id.ToString() == selectedStudentId);
            if (selectedStudent != null)
            {
                LoadSelectedCourses(selectedStudent);
            }
        }


        // Show Error Message
        private void ShowErrorMessage(string message)
        {
            ErrorLabel.Text = message;
            ErrorLabel.Visible = true;
        }

        private void PopulateStudentDropdown()
        {
            foreach (Student student in Students)
            {
                ListItem item = new ListItem(student.ToString(), student.Id.ToString());
                StudentDropdown.Items.Add(item);
            }
        }
    }
}
