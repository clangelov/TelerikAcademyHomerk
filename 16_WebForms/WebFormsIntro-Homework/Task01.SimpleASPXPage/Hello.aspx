<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="Task01.SimpleASPXPage.Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple ASPX page</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
</head>
<body>
    <div class="container-fluid">
        <div class="well bs-component">
            <form class="form-horizontal" id="helloForm" runat="server">
                <fieldset>
                    <legend>Hi,
                        <asp:Label ID="Result" runat="server"></asp:Label>
                    </legend>
                    <div class="form-group">
                        <label for="Name" class="col-lg-2 control-label">Enter your name: </label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="Name" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10">
                            <asp:Button ID="Btn" runat="server" OnClick="Btn_Click" Text="Add Name!" CssClass="btn btn-default" />
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/jquery-2.2.0.min.js" type="text/javascript"></script>
</body>
</html>
