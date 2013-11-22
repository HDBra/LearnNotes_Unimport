<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="AspNet4.Controls.CategoryList" %>

<%= CreateHomeLinkHtml() %>

<%
    foreach (string cat in GetCategories())
    {
        Response.Write(CreateLinkHtml(cat));
    }
%>