<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="phoneHomeOfficeDept.aspx.vb" Inherits="Main_phoneHomeOfficeDept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2>Home Office Phone Directory</h2>
    <br />

    <table  width="100%" border="0">
        <tr>
            <td align="left"><asp:HyperLink ID="lnkHOName" runat="server">View By Name</asp:HyperLink></td>
            <td align="right"><asp:HyperLink ID="lnkHOExt" runat="server" >View By Extension</asp:HyperLink></td>
        </tr>
    </table>
    
    <br />
    <table width="100%" border="0" align="center">
        <tr>
            <td valign="top" align="center">
                    <asp:Table ID="tblDept" runat="server" Width="600px" HorizontalAlign="Center" CellPadding="1" CellSpacing="1"></asp:Table></td>
        </tr>
    </table>

    <hr width="100%" />
    <br />
    <br />
    <br />

</asp:Content>

