<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Task03.StudentsRegistration.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Students and Courses</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" />
</head>
<body>
    <form id="registration" runat="server">
        <div class="container row">
            <div class="well bs-component col-md-8 col-md-offset-2">
                <fieldset>
                    <legend>Enter your details</legend>
                    <div class="form-group">
                        <asp:Label runat="server" Text="First Name" class="col-lg-2 control-label" />
                        <div class="col-lg-10">
                            <asp:TextBox ID="FirstName" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Last Name" class="col-lg-2 control-label" />
                        <div class="col-lg-10">
                            <asp:TextBox ID="LastName" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Faculty Number" class="col-lg-2 control-label" />
                        <div class="col-lg-10">
                            <asp:TextBox ID="FacultyNumber" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="University" class="col-lg-2 control-label" />
                        <div class="col-lg-10">
                            <asp:DropDownList ID="University" runat="server" SelectMethod="GetUniversities" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Speciality" class="col-lg-2 control-label" />
                        <div class="col-lg-10">
                            <asp:DropDownList ID="Speciality" runat="server" SelectMethod="GetSpecialities" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Courses" class="col-lg-2 control-label" />
                        <div class="col-lg-10">
                            <asp:CheckBoxList ID="Courses" runat="server" SelectMethod="GetCourses" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10">
                            <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Submit form" />
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
        <br />
        <div class="container" id="ResultDiv" runat="server" visible="false">
            <div class="well bs-component">
                <div class="row">
                    <div class="row col-lg-6 col-lg-offset-3">
                        <h2>Result</h2>
                    </div>
                    <div class="row col-lg-6 col-lg-offset-3">
                        <asp:Literal Mode="Encode" ID="Name" runat="server" />
                    </div>
                    <div class="row col-lg-6 col-lg-offset-3">
                        <asp:Literal Mode="Encode" ID="Number" runat="server" />
                    </div>
                    <div class="row col-lg-6 col-lg-offset-3">
                        <asp:Literal Mode="Encode" ID="UniSpec" runat="server" />
                    </div>
                    <div class="row col-lg-6 col-lg-offset-3">
                        <asp:Literal Mode="Encode" ID="SelectedCourses" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-2.2.0.min.js" type="text/javascript"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
