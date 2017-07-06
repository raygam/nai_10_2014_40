<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="phoneDistrictDetail.aspx.vb" Inherits="Main_phoneDistrictDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    <br />

    <asp:Label ID="lblMessage" runat="server" CssClass="MESSAGE_TEXT" Text=""></asp:Label>
    <br />

    <table width="100%" border="0">
        <tr>
            <td align="center">
                <asp:DropDownList ID="ddlCA" runat="server" CssClass="DATA_LABEL"  
                    AutoPostBack="True" Width="350px">
                </asp:DropDownList>        
            </td>
        </tr>
    </table>
    <br />
    <br />

    <table width="100%" border="0">
        <tr>
            <td valign="top" align="center" >
                <asp:Table ID="tblCA" runat="server" Width="300px" HorizontalAlign="Center" 
                    CellPadding="1" CellSpacing="0"></asp:Table></td>
            <td valign="top" align="center">
                <asp:Table ID="tblCM" runat="server" Width="300px" HorizontalAlign="Center" 
                    CellPadding="1" CellSpacing="0"></asp:Table></td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td valign="top" colspan="2">
                    <asp:Table ID="tblTheatres" runat="server" Width="650px" HorizontalAlign="Center" CellPadding="1" CellSpacing="0"></asp:Table></td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
    </table>

    <br />
    <br />
    <br />
    
</asp:Content>

