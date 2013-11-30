<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Handlers.Default" %>
<%@ Register tagPrefix="Events" tagName="Counter" src="~/ViewCounter.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        The time is <%: DateTime.Now.ToShortDateString() %>
        <Events:Counter ID="counter" runat="server" />
    </div>
    </form>
</body>
</html>
