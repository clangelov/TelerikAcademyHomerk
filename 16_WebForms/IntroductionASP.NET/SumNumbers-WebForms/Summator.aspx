<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summator.aspx.cs" Inherits="SumNumbers_WebForms.Summator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Introduction to ASP.NET Homework</title>
</head>
<body>
    <form id="summator" runat="server">
    <div>
        First Number:
        <input id="firstNumber" type="number" runat="server"/>
        <br />
        <br />      
        Second Number:
        <input id="secondNumber" type="number" runat="server"/>
        <br />
        <asp:Button ID="Sum" runat="server" Text="Sum Numbers" OnClick="Sum_Numbers" />
        <br />
    </div>
    <div runat="server">
        <h3><asp:Label ID="SumResult" runat="server" Text="" Visible="false" /></h3>
    </div>
    </form>
</body>
</html>
