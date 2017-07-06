<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="menuPhoneList.aspx.vb" Inherits="Main_menuPhoneList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2>Phone List Options</h2>
    <br />

    <table width="100%" border="0">
        <tr>
            <td valign="top"><asp:Table ID="tblPhone1" runat="server" Width="250px" HorizontalAlign="Center"></asp:Table></td>
            <td valign="top"><asp:Table ID="tblPhone2" runat="server" Width="250px" HorizontalAlign="Center"></asp:Table></td>
        </tr>
    </table>

    <br />
    <br />

</asp:Content>

