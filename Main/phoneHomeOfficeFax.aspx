<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="phoneHomeOfficeFax.aspx.vb" Inherits="Main_phoneHomeOfficeFax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <h2>Home Office Fax Numbers</h2>
    <br />

    <table width="400px" border="0" align="center">
        <tr><td><hr width="100%"</td></tr>
        <tr>
            <td valign="top" align="center">
                    <asp:Table ID="tblFax" runat="server" Width="350px" HorizontalAlign="Center" CellPadding="0" CellSpacing="0"></asp:Table></td>
        </tr>
        <tr><td><hr width="100%"</td></tr>
    </table>

    <br />
    <br />
    <br />

</asp:Content>

