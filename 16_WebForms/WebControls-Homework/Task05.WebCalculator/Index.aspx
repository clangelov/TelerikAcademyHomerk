<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Task05.WebCalculator.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Calculator</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" />
    <link href="calculator.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row-fluid">
                <div class="span6 well">
                    <div id="calc-board">
                        <div class="row-fluid myresult">
                            <asp:Literal Mode="Encode" ID="Result" runat="server" Text="0"></asp:Literal>
                        </div>
                        <div class="row-fluid">
                            <asp:Button Text="1" runat="server" OnCommand="Digit_Click" CommandArgument="1" class="btn btn-primary mybtn" />
                            <asp:Button Text="2" runat="server" OnCommand="Digit_Click" CommandArgument="2" class="btn btn-primary mybtn" />
                            <asp:Button Text="3" runat="server" OnCommand="Digit_Click" CommandArgument="3" class="btn btn-primary mybtn" />
                            <asp:Button Text="+" runat="server" OnCommand="Operation_Click" CommandArgument="+" class="btn btn-primary mybtn" />
                        </div>
                        <div class="row-fluid">
                            <asp:Button Text="4" runat="server" OnCommand="Digit_Click" CommandArgument="4" class="btn btn-primary mybtn" />
                            <asp:Button Text="5" runat="server" OnCommand="Digit_Click" CommandArgument="5" class="btn btn-primary mybtn" />
                            <asp:Button Text="6" runat="server" OnCommand="Digit_Click" CommandArgument="6" class="btn btn-primary mybtn" />
                            <asp:Button Text="-" runat="server" OnCommand="Operation_Click" CommandArgument="-" class="btn btn-primary mybtn" />
                        </div>
                        <div class="row-fluid">
                            <asp:Button Text="7" runat="server" OnCommand="Digit_Click" CommandArgument="7" class="btn btn-primary mybtn" />
                            <asp:Button Text="8" runat="server" OnCommand="Digit_Click" CommandArgument="8" class="btn btn-primary mybtn" />
                            <asp:Button Text="9" runat="server" OnCommand="Digit_Click" CommandArgument="9" class="btn btn-primary mybtn" />
                            <asp:Button Text="X" runat="server" OnCommand="Operation_Click" CommandArgument="*" class="btn btn-primary mybtn" />
                        </div>
                        <div class="row-fluid">
                            <asp:Button Text="C" runat="server" OnClick="Clear_Click" class="btn btn-danger mybtn" />
                            <asp:Button Text="0" runat="server" OnCommand="Digit_Click" CommandArgument="0" class="btn btn-primary mybtn" />
                            <asp:Button Text="/" runat="server" OnCommand="Operation_Click" CommandArgument="/" class="btn btn-primary mybtn" />
                            <asp:Button ID="SqRootBtn" runat="server" OnCommand="Operation_Click" CommandArgument="sr" class="btn btn-primary mybtn" />
                        </div>
                        <div class="row-fluid">
                            <asp:Button Text="=" runat="server" OnClick="Calculate_Click" class="btn btn-warning myequals" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-2.2.0.min.js" type="text/javascript"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
