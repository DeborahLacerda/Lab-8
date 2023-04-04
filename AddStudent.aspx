<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab_8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Include Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js"></script>
    <title>Add Student</title>

</head>
<body>
    <div class="container bg-light ">
        <form id="form1" runat="server" class="form-group">
            <div >
                <h1 class="text-center text-success">Students</h1>
                 <br />
                <label for="name">Name:</label>
                <asp:TextBox ID="name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="nameValidator" runat="server" class="text-danger fs-5"  ControlToValidate="name" ErrorMessage="Name is required!" /><br />
                <br />

                <label for="type">Type:</label>
                <asp:DropDownList ID="type" runat="server" class="btn btn-success dropdown-toggle">
                    <asp:ListItem Text="Select..." Value=""></asp:ListItem>
                    <asp:ListItem Text="Full Time" Value="fulltime"></asp:ListItem>
                    <asp:ListItem Text="Part Time" Value="parttime"></asp:ListItem>
                    <asp:ListItem Text="Coop" Value="coop"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="typeValidator" runat="server" class="text-danger fs-5" ControlToValidate="type" ErrorMessage="Type is required!" /><br />
                <br />

                <asp:Button ID="add" runat="server" Text="Add" OnClick="Add_Click" class="btn btn-outline-success" /><br />
                <br />

            </div>
            <div>
                <asp:Table ID="Table1" runat="server" CssClass="table table-hover">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell Scope="Column" Text="ID"></asp:TableHeaderCell>
                        <asp:TableHeaderCell Scope="Column" Text="Name"></asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>

        </form>
          <br />
        <div class="d-grid gap-2 col-6 mx-auto">
            <a href="RegisterCourse.aspx" class="btn btn-secondary ">Register for Courses</a>
        </div>
    </div>

    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js"></script>

</body>
</html>
