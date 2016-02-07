<%@ Page Title="About Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CasheApplication.About" %>

<%@ OutputCache CacheProfile="OneHourCache" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2><%: Title %>.</h2>
        <h3>This page will be cached for 1 hour </h3>
        <p>With a cache profile, see the web.config as well</p>
        <h3>Time: <%= DateTime.Now %></h3>
    </div>
</asp:Content>
