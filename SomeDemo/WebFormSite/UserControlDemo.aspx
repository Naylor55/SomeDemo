<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserControlDemo.aspx.cs" Inherits="WebFormSite.UserControlDemo" %>

<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Header runat="server" id="Header" />
    </div>
    </form>
</body>
</html>
