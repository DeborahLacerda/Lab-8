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

                return;
            }
        }


        protected void SubmitButton_Click(object sender, EventArgs e)
        {

            // Check if student is provided
            string selectedStudentId = StudentDropdown.Value;
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

        private void ShowSelectedCourses(List<Course> selectedCourses)
        {
            //Clean
            ErrorLabel.Text = "";
            ErrorLabel.Visible = false;

            tableh2.Text = "Has Enrolled in thee following couses";
            tableh2.Visible = true;
            StudentDropdown.Disabled = true;
            //para cada curso c em cursoselecionados
            Table1.Visible = true;
            foreach (Course c in selectedCourses)
            {
                // Create registration table row
                TableRow row = new TableRow();
                TableCell codeCell = new TableCell();
                TableCell coursesCell = new TableCell();
                TableCell hoursCell = new TableCell();


                codeCell.Controls.Add(new LiteralControl(c.Code));
                coursesCell.Controls.Add(new LiteralControl(c.Title));
                hoursCell.Controls.Add(new LiteralControl(c.WeeklyHours.ToString()));
                row.Cells.Add(codeCell);
                row.Cells.Add(coursesCell);
                row.Cells.Add(hoursCell);


                Table1.Rows.Add(row);
            }

            // Calculate total hours
            int totalSelectedHours = selectedCourses.Sum(c => c.WeeklyHours);

            // Add total hours row to table
            TableRow totalRow = new TableRow();
            Table1.Rows.Add(totalRow);

            TableCell totalCell = new TableCell();
            totalCell.Text = "Total Hours";
            totalCell.ColumnSpan = 2;
            totalCell.HorizontalAlign = HorizontalAlign.Right;
            totalRow.Cells.Add(totalCell);

            TableCell totalHoursCell = new TableCell();
            totalHoursCell.Text = totalSelectedHours.ToString();
            totalRow.Cells.Add(totalHoursCell);


            title1.Visible = false;
            CoursesCheckBoxList.Visible = false;
            cmdOK.Visible = false;
            Table1.Visible = true;
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

        // Get Total Weekly Hours
        public static int GetTotalWeeklyHours(CheckBoxList coursesCheckBoxList)
        {
            int totalHours = 0;
            foreach (ListItem item in coursesCheckBoxList.Items)
            {
                if (item.Selected)
                {
                    totalHours += Helper.GetCourseByCode(item.Value).WeeklyHours;
                }
            }
            return totalHours;
        }
        //Show Error Message
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
