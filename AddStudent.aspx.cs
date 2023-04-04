using Lab_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // initialize the student list in session if it doesn't exist
            if (Session["students"] == null)
            {
                Session["students"] = new List<Student>();
            }
            List<Student> students = (List<Student>)Session["students"];
            if (students.Count == 0)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.ColumnSpan = 3;
                cell.Text = "No Student Yet!";
                row.Cells.Add(cell);
                Table1.Rows.Add(row);
            }
            else
            {
                RefreshTable();
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string studentName = name.Text;
            string studentType = type.SelectedValue;

            if (IsValid)
            {
                // create a student object based on the selected type
                Student student;
                if (studentType == "fulltime")
                {
                    student = new FulltimeStudent(studentName);
                }
                else if (studentType == "parttime")
                {
                    student = new ParttimeStudent(studentName);
                }
                else // studentType == "coop"
                {
                    student = new CoopStudent(studentName);
                }

                // add the student to the list in session
                List<Student> students = (List<Student>)Session["students"];
                students.Add(student);

                // clear the name text box and reset the type dropdown list
                name.Text = "";
                type.SelectedValue = "";

                

            }
            // Refresh the table
            Response.Redirect("AddStudent.aspx");
        }

         private void RefreshTable()
        {
            List<Student> students = (List<Student>)Session["students"];

            foreach (Student c in students)
            {
                // Create registration table row
                TableRow row = new TableRow();
                TableCell name = new TableCell();
                TableCell id = new TableCell();


                name.Controls.Add(new LiteralControl(c.Name));
                id.Controls.Add(new LiteralControl(c.Id.ToString()));
                row.Cells.Add(id);
                row.Cells.Add(name);

                Table1.Rows.Add(row);
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value.Trim().Length > 0);
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value.Trim().Length > 0);
        }
    }
}
