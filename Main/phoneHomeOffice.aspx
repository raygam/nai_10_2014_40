<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="phoneHomeOffice.aspx.vb" Inherits="Main_phoneHomeOffice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2>Home Office Phone Directory</h2>
    <br />

    <table  width="100%" border="0">
        <tr>
            <td align="left"><asp:HyperLink ID="lnkHO" runat="server">View By Extension</asp:HyperLink></td>
            <td align="right"><asp:HyperLink ID="lnkDept" runat="server" >View By Department</asp:HyperLink></td>
        </tr>
    </table>
    
    <br />

    <table width="100%" border="0">
        <tr>
            <td valign="top">
                    <asp:Table ID="tblPhone1" runat="server" Width="185px" HorizontalAlign="Center" CellPadding="0" CellSpacing="0"></asp:Table></td>
            <td valign="top">
                    <asp:Table ID="tblPhone2" runat="server" Width="185px" HorizontalAlign="center" CellPadding="0" CellSpacing="0"></asp:Table></td>
            <td valign="top">
                    <asp:Table ID="tblPhone3" runat="server" Width="185px" HorizontalAlign="center" CellPadding="0" CellSpacing="0"></asp:Table></td>
        </tr>
    </table>

    <br />
    <br />
    <br />

</asp:Content>

