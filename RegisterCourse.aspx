<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab_8.RegisterCourse" %>

<!DOCTYPE html>
<html>
<head>
    <title>Registrations</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container bg-light ">
        <form id="form1" runat="server" class="form-group">
            <div>
                <h1 class="text-center text-success">Registrations</h1>
                <br />
                <label for="StudentDropdown">Student:</label>
                <select id="StudentDropdown" runat="server" class="btn btn-success dropdown-toggle">
                    <option value="">-- Select a student --</option>
                </select>
                <br />

                <asp:Label class="text-danger fs-5" ID="Label2" runat="server" Visible="false" />
                <span id="StudentError" class="text-danger" style="display: none;">Please select a student.</span>

                <asp:Label class="text-danger fs-5" ID="Label1" runat="server" Visible="false" />

            </div>
            <div>
                <asp:Label class="text-danger fs-5" ID="ErrorLabel" runat="server" Visible="false" />

                <br />
                <h4>
                    <asp:Label ID="title1" runat="server" Visible="false" />

                </h4>

                <asp:CheckBoxList ID="CoursesCheckBoxList" runat="server" Visible="true" />
            </div>
            <br />

            <asp:Button ID="cmdOK" Text="Save" runat="server" class="btn btn-outline-success" OnClick="SubmitButton_Click" Visible="true" />

            <div>
                <h2>
                    <asp:Label ID="tableh2" runat="server" Visible="false" /></h2>

                <asp:Table ID="Table1" runat="server" CssClass="table table-hover" Visible="false">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell Scope="Column" Text="Course Code"></asp:TableHeaderCell>
                        <asp:TableHeaderCell Scope="Column" Text="Course Title"></asp:TableHeaderCell>
                        <asp:TableHeaderCell Scope="Column" Text="Weekly Hours"></asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </form>
          <br />
        <div class="d-grid gap-2 col-6 mx-auto">
            <a href="AddStudent.aspx" class="btn btn-secondary ">Add Student</a>
        </div>
    </div>
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js"></script>

</body>
</html>

