<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Smart House</title>
    <link runat="server" href="Style.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <header runat="server" class="header">	
        
	</header>
    <form id="form1" runat="server" class="wrapper">
        <div id="headerLine">
            <asp:DropDownList ID="dropDownDevicesList" runat="server">
                <asp:ListItem>Fridge</asp:ListItem>
                <asp:ListItem>Hoover</asp:ListItem>
                <asp:ListItem>Bicycle</asp:ListItem>
                <asp:ListItem>Television</asp:ListItem>
                <asp:ListItem>Warhammer</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="addDevicesButton" runat="server" Text="Add Device" />
            </div>
        <div id="devBody">
            
            <asp:Panel ID="devicesPanel" runat="server" ></asp:Panel>
        </div>
    </form>
</body>
</html>