<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="econtactMaintain.aspx.vb" Inherits="Main_econtactMaintain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    <br />

    <asp:Label ID="lblMessage" runat="server" CssClass="MESSAGE_TEXT" Text=""></asp:Label>
    <br />

    <asp:Table ID="tblEmp" runat="server" CssClass="DATA" GridLines="None" HorizontalAlign="Center" Width="600px" CellSpacing=0>
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="txtSearch" runat="server" Width="125px" CssClass="DATA_XS" Text="" Visible="False"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="cmdSearch" runat="server" Width="75px" Text="Search"  CssClass="BUTTON_TEXT" Visible="False" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right"><asp:LinkButton ID="lnkExport" runat="server"  >Export All to Excel</asp:LinkButton></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                <asp:Table ID="tblResults" runat="server" GridLines="None" Width="600" >
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    </asp:Table>
    <br />
    <br />

</asp:Content>

