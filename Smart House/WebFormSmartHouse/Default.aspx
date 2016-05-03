<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormSmartHouse.Default" %>

<%--<%@ Register Src="~/Controls/WfDevice.ascx" TagPrefix="uc1" TagName="WfDevice" %>--%>

<%--<uc1:WfDevice runat="server" id="WfDevice" />--%>







<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>WebFormSmartHouse</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <img id="logo" src="Images/Logo.png" />
        <br />
        <div id="headerContpol">
            <asp:Button ID="addDevicesButton" runat="server" Text="Add" />
            <asp:DropDownList ID="DropDownListDevices" runat="server">
                <asp:ListItem>Television</asp:ListItem>
                <asp:ListItem>Radioreceiver</asp:ListItem>
                <asp:ListItem>Fridge</asp:ListItem>
            </asp:DropDownList>
        </div> 
    </div>
    <div class="devicePanel">
        <asp:Panel ID="devicesPanel" runat="server"></asp:Panel>
    </div>
    </form>
</body>
</html>
