<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="WebForms.Events" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        th, td {
            border: thin solid black;
            text-align: left;
            padding: 3px;
            width:120px;
        }
        table {
            border-collapse: collapse;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2><%: Application["message"] %></h2>
        <table id="eventTable">
            <tr><th>Source</th><th>Type</th></tr>
            <asp:Repeater SelectMethod="GetEvents" ItemType="WebForms.Models.EventDescription" runat="server">
                <ItemTemplate>
                    <tr><td><%# Item.Source %></td><td><%# Item.Type %></td></tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
