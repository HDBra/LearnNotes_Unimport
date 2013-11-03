<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>Name:</label>
            <input id="name" runat="server" />
        </div>
        <div>
            <label>City:</label>
            <input id="city" runat="server" />
        </div>
        <button type="submit">submit</button>
    </form>
    <p id="target" runat="server"></p>
</body>
</html>
