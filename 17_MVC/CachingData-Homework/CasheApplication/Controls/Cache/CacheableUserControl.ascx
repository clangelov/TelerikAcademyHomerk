<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CacheableUserControl.ascx.cs" Inherits="CasheApplication.Controls.Cache.CacheableUserControl" %>
<%@ OutputCache Duration="5" VaryByParam="none" Shared="true" %>
<div>
    <h3>Cachable user control</h3>
    <p>It will last for 5 seconds</p>
    <h3>Time is: <%= DateTime.Now %></h3>
</div>