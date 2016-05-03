<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WfDevice.ascx.cs" Inherits="WebFormSmartHouse.WebUserControl1" %>

<div class="divBody">
    <asp:Panel ID="PnlMain" runat="server">
        <div class="topLine">
            <div class="lblName">
                <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
            </div>
            <asp:Button ID="btnPowerStatus" runat="server" ToolTip="ON/OFF" />
        </div>
        <asp:Panel ID="pnlProperties" CssClass="propertiesPanel" runat="server"></asp:Panel>
        

    </asp:Panel>












</div>