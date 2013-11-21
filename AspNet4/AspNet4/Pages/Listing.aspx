<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="AspNet4.Pages.Listing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SportsStore</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%
                foreach (var prod in GetProducts())
                {
                    Response.Write("<div class='item'>");
                    Response.Write(string.Format("<h3>{0}</h3>", prod.Name));
                    Response.Write(prod.Description);
                    Response.Write(string.Format("<h4>{0:c}</h4>", prod.Price));

                    Response.Write("<hr /></div>");
                }
            %>
        </div>
        <div>
            <% for (int i = 1; i <= MaxPage; i++)
               {
                   Response.Write(
                   string.Format("<a href='/Pages/Listing.aspx?page={0}' {1}>{2}</a>",
                   i, i == CurrentPage ? "class='selected'" : "", i));
               }%>
        </div>
    </form>
</body>
</html>
