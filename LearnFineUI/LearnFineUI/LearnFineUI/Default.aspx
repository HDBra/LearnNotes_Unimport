<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LearnFineUI.Default" %>
<%@ Register assembly="ExtAspNet" namespace="ExtAspNet" tagPrefix="f" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="mainPageManager" AjaxAspnetControls="Label1,Literal1" runat="server" />
       
        <f:DropDownList Label="DropDownList1" AutoPostBack="False" Required="True" EnableSimulateTree="True" ShowRedStar="True" ID="ddlBox" Resizable="True" runat="server">
        </f:DropDownList>

    </form>
</body>
</html>
