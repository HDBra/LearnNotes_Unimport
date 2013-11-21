<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" MasterPageFile="~/Pages/Store.Master" Inherits="AspNet4.Pages.Listing" %>

<%@ Import Namespace="AspNet4.Models" %>
<%@ Import namespace="System.Web.Routing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <%foreach (Product prod in GetProducts())
          {
              Response.Write("<div class='item'>");
              Response.Write(string.Format("<h3>{0}</h3>", prod.Name));
              Response.Write(prod.Description);
              Response.Write(string.Format("<h4>{0:c}</h4>", prod.Price));
              Response.Write("</div>");
          }%>
    </div>
    <div class="pager">
        <% for (int i = 1; i <= MaxPage; i++)
           {
               Response.Write(
               string.Format("<a href='/Pages/Listing.aspx?page={0}' {1}>{2}</a>",
               i, i == CurrentPage ? "class='selected'" : "", i));
           }%>
    </div>
</asp:Content>
