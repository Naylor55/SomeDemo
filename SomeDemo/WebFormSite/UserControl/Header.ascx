<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="WebFormSite.UserControl.Header" %>

<h4>Header用户控件</h4>
<br />
<br />
<%@ Register Src="~/UserControl/Weather.ascx" TagPrefix="uc1" TagName="Weather" %>

<uc1:Weather runat="server" id="Weather" />
