<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="menuContactUs.aspx.vb" Inherits="Main_menuContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2>Contact Us</h2>
    <br />

    <table align="center" width="550px" border="0">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" CssClass="MESSAGE_TEXT"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name:" CssClass="DATA_LABEL"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" CssClass="DATA" Width="275px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Email Address:" 
                    CssClass="DATA_LABEL"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="DATA" Width="275px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Subject:" CssClass="DATA_LABEL"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubject" runat="server" CssClass="DATA">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label4" runat="server" Text="Message:" CssClass="DATA_LABEL"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBody" runat="server" Height="121px" TextMode="MultiLine" 
                    Width="396px" CssClass="DATA"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="cmdSend" runat="server" Text="Send Message" CssClass="BUTTON_TEXT" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
    </table>

    <br />
    <br />

</asp:Content>

