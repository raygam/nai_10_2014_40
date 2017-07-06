<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="phoneEmpMain.aspx.vb" Inherits="Main_phoneEmpMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    <br />

    <asp:Label ID="lblMessage" runat="server" CssClass="MESSAGE_TEXT" Text=""></asp:Label>
    <br />

    <asp:Table ID="tblEmp" runat="server" CssClass="DATA" GridLines="None" HorizontalAlign="Center" Width="450px">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:Label ID="Label1" runat="server" Text="Select Employee to Edit or Add a New Employee" CssClass="DATA_LABEL"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:DropDownList ID="ddlEmps" runat="server" CssClass="DATA" Width="200px">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:Button ID="cmdAdd" runat="server" Text="Add New Employee" Width="125px" CssClass="BUTTON_TEXT" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="cmdEdit" runat="server" Text="Edit Employee" Width="125px" CssClass="BUTTON_TEXT" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="cmdRemove" runat="server" Text="Remove Employee" Width="125px" CssClass="BUTTON_TEXT" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:Button ID="cmdReturn" runat="server" Text="Return" Width="125px" CssClass="BUTTON_TEXT"  />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />

</asp:Content>

