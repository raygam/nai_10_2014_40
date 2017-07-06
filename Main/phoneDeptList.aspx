<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="phoneDeptList.aspx.vb" Inherits="Main_phoneDeptList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    <br />

    <table width="100%" border="0">
        <tr>
            <td valign="top">
                    <asp:Table ID="tblDept" runat="server" Width="450px" HorizontalAlign="Left" CellPadding="1" CellSpacing="0"></asp:Table></td>
        </tr>
        <tr><td>&nbsp;</td></tr>
    </table>

    <br />
    <br />
    <br />

</asp:Content>

