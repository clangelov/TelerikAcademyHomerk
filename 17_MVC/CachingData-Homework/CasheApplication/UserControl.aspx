<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserControl.aspx.cs" Inherits="CasheApplication.UserControl" %>

<%@ Register Src="~/Controls/Cache/CacheableUserControl.ascx" TagPrefix="ucontrol" TagName="CacheableUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="container">
            <div class="col-lg-8 col-lg-offset-2">
                <ucontrol:CacheableUserControl runat="server" id="CacheableUserControl" />
            </div>
        </div>
    </div>
</asp:Content>
