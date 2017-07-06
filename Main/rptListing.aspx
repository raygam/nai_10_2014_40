<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="rptListing.aspx.vb" Inherits="Main_rptListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2>Report Listing</h2>
    <br />

    <asp:Label ID="lblMessage" runat="server" CssClass="MESSAGE_TEXT" Text=""></asp:Label>
    <br />

    <table width="100%" border="0">
        <tr>
            <td valign="top">
                    <asp:Table ID="rptTable" runat="server" Width="600px" HorizontalAlign="Center" CellPadding="1" CellSpacing="0"></asp:Table></td>
        </tr>
        <tr><td>&nbsp;</td></tr>
    </table>

    <br />
    <br />
    <br />

</asp:Content>

