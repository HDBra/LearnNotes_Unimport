<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LearnFineUI.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server" />
        
        <f:Panel Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="End"  BoxConfigPadding="5" BoxConfigChildMargin="0 0 5 0" runat="server">
            <Items>
                <f:Panel BoxFlex="1" runat="server"/>
                <f:Panel Height="100px" runat="server"/>
                <f:Panel BoxFlex="2" BoxMargin="0" runat="server"/>
            </Items>
        </f:Panel>
        <!-- 
            
            BoxConfigAlign:用来控制容器子控件的尺寸，有四种取值：
            Start：所有子控件位于父容器开始位置
            Center:所有子控件位于父容器的中间位置
            Stretch:所有子控件被拉伸至父容器的大小
            StretchMax:所有子控件被拉伸至最大子控件的大小
             -->

    </form>
</body>
</html>
