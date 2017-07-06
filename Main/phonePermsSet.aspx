<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="phonePermsSet.aspx.vb" Inherits="Main_phonePermsSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    <br />

    <asp:Label ID="lblMessage" runat="server" CssClass="MESSAGE_TEXT" Text=""></asp:Label>
    <br />

    <asp:Table ID="tblPerms" runat="server" CssClass="DATA" GridLines="None" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell Width="250px"></asp:TableCell>
            <asp:TableCell Width="250px"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList ID="ddlEmps" CssClass="DATA" runat="server" AutoPostBack="True" Width="200px"></asp:DropDownList></asp:TableCell>
            <asp:TableCell><asp:CheckBox ID="chkUpdate" runat="server" CssClass="DATA"  Text="Update Personnel" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:CheckBox ID="chkAuditOffice" runat="server" CssClass="DATA" Text="View Auditor Office" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:CheckBox ID="chkAuditHome" runat="server" CssClass="DATA" Text="View Auditor Home" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:CheckBox ID="chkOpsMgmt" runat="server" CssClass="DATA" Text="View Operations Management" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:CheckBox ID="chkOpsSupport" runat="server" CssClass="DATA" Text="View Operations Support" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:CheckBox ID="chkOpsUpdate" runat="server" CssClass="DATA" Text="Update Operations" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:CheckBox ID="chkDMView" runat="server" CssClass="DATA" Text="View Area Managers" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:CheckBox ID="chkDMUpdate" runat="server" CssClass="DATA" Text="Update Area Managers" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:CheckBox ID="chkDOUpdate" runat="server" CssClass="DATA" Text="Update Area Offices" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center"><asp:Button ID="cmdSave" runat="server" CssClass="BUTTON_TEXT" Text="Save" Width="125px" /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center"><asp:Button ID="cmdReturn" CssClass="BUTTON_TEXT" runat="server" Text="Return" Width="125px" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblId" runat="server" Text="" Visible="false" CssClass="DATA"></asp:Label></asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblAlias" runat="server" Text="" Visible="false" CssClass="DATA"></asp:Label>
                <asp:Label ID="lblSecurityNum" runat="server" Text="" Visible="false" CssClass="DATA"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />

</asp:Content>

