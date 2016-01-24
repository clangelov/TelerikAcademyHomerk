<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Task02.Escaping.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Escaping HTML</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" />
</head>
<body>
    <form id="escapingForm" runat="server">
        <div class="container">
            <div class="well bs-component">
                <fieldset>
                    <legend>Escaping Homework
                    </legend>
                    <div class="form-group">
                        <label for="UnEscapedText" class="col-lg-2 control-label">Dangerous HTML </label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="UnEscapedText" class="form-control" runat="server" ValidateRequestMode="Disabled" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10">
                            <asp:Button ID="ButtonSubmit" runat="server" CssClass="btn btn-default"
                                Text="Display Text" OnClick="ButtonDisplayText" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10">
                            <br />
                            <asp:Label ID="ResultEscaped" runat="server" Text="" Visible="false" />
                            <asp:Literal ID="LiteralEscaped" runat="server" Mode="Encode" />
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </form>    
    <script src="https://code.jquery.com/jquery-2.2.0.min.js" type="text/javascript"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
